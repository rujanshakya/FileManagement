using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using MiniProjectFile.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Z.Dapper.Plus;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace MiniProjectFile.Controllers
{
    public class ImportSourcesController : Controller
    {
        private readonly EntityFrameWork _context;
        private readonly DapperContext _Dcontext;


        public ImportSourcesController(EntityFrameWork context, DapperContext dcontext)
        {
            _context = context;
            _Dcontext = dcontext;
        }

        /*public string SaveTable(string[] function_param)
        {
            if (function_param != null)
            {
                //some code
                Console.WriteLine(function_param);
                return "Success";
            }

            //The following code will run if it's not successful. 
            return "There must be at least one country in the Region.";
            //Yeah it's always returning this b/c function_param is null;         
        }*/

        // GET: ImportSources
        public async Task<IActionResult> Index()
        {
            //Testing Linq query
            /*var customquery= from da in _context.ColumnModel where da.ImportSourceId == 82 select da;
            foreach (var customer in customquery)
            {
                Console.WriteLine(customer.Id + ", " + customer.HeaderName + ", " + customer.ImportSourceId);
            }*/

            return View(await _context.ImportSource.ToListAsync());
        }

        // GET: ImportSources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ImportSource == null)
            {
                return NotFound();
            }
           ;
            var importSource = await _context.ImportSource
                .FirstOrDefaultAsync(m => m.Id == id);
            if (importSource == null)
            {
                return NotFound();
            }

            return View(importSource);
        }

        // GET: ImportSources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ImportSources/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,FileName,FilePath,FileFormat,CreatedBy,CreatedOn")] ImportSource importSource, [Bind("Column")] string column, [Bind("TableData")] string tabledata)
        {
            //getting column data and changing it to an array
            List<string> objectColumn = JsonConvert.DeserializeObject<List<string>>(column);
            /*            var TableData = JsonConvert.DeserializeObject(tabledata);
            */            /*            Console.WriteLine(TableData);
                        */


            /*            ColumnModel childModel = new ColumnModel();
            */            //parentModel.childmodel = List<childModel>
                          //childModel: id, headerName 
                          //parent model persist into database, Output param=primary key



            ImportSource parentModel = new ImportSource();
            List<ColumnModel> tempColumn = new List<ColumnModel>();



            foreach (var col in objectColumn)
            {
                Console.Write(col + "\n");
            }
            /*            childModel.ImportSourceId = importSource.Id;
            *//*            childModel.HeaderName = column;
            */
            foreach (var col in objectColumn)
            {

                tempColumn.Add(new ColumnModel() { ImportSourceId = parentModel.Id, HeaderName = col });
            }


            //for child model

            //creating model for parent
            parentModel.Id = importSource.Id;
            parentModel.FileName = importSource.FileName;
            parentModel.Name = importSource.Name;
            parentModel.FilePath = importSource.FilePath;
            parentModel.FileFormat = importSource.FileFormat;
            parentModel.CreatedBy = importSource.CreatedBy;
            parentModel.CreatedOn = importSource.CreatedOn;
            parentModel.Column = column;
            parentModel.Columns = tempColumn;
            parentModel.TableData = tabledata;
            /*            var mo = tempColumn;
            */



            //id=primaryKey, headerName=col.value
            //create pure model

            //bind with the column 
            //We have parent model and child model new { id(FK), headerName}
            //parentModel.ChildModels.Add(new ChildModel() { 1,"" });/anonymous class

            //child model persist into database.


            /*            Console.WriteLine(objectColumn);
            */            /*            string columnstring= JsonConvert.SerializeObject(objectColumn);
                        *//*            Console.WriteLine(columnstring);
                        *//*            var result = objectColumn.SelectMany(x => x["Staffs"]).Values<int>().ToList();
                        */
            /*Console.WriteLine(objectColumn.GetType());*/
            /*            Console.WriteLine(columnstring.GetType());
            */


            /*System.Type type = typeof(objectColumn);
            Console.WriteLine(type);*/

            if (ModelState.IsValid)
            {

                _context.Add(parentModel);
                await _context.SaveChangesAsync();

                //create table from model data

                return RedirectToAction(nameof(Index));
            }

            return View(importSource);


        }

        // GET: ImportSources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ImportSource == null)
            {
                return NotFound();
            }

            var importSource = await _context.ImportSource.FindAsync(id);
            if (importSource == null)
            {
                return NotFound();
            }
            return View(importSource);
        }

        // POST: ImportSources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,FileName,FilePath,FileFormat,CreatedBy,CreatedOn")] ImportSource importSource, [Bind("Column")] string column)
        {
            if (id != importSource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ImportSource updateModel = new ImportSource();
                    updateModel = importSource;
                    updateModel.Column = column;
                    List<string> objectColumn = JsonConvert.DeserializeObject<List<string>>(column);


                    List<ColumnModel> tempColumn = new List<ColumnModel>();

                    foreach (var col in objectColumn)
                    {

                        tempColumn.Add(new ColumnModel() { ImportSourceId = importSource.Id, HeaderName = col });
                    }

                    updateModel.Columns = tempColumn;

                    /*var columnmodel = await _context.ColumnModel.FirstOrDefaultAsync(x => x.ImportSourceId == id);
                    _context.Remove(columnmodel);
                */
                    /*var columnmodel= await _context.ColumnModel.Where(x=>x.ImportSourceId== ).ToListAsync();
                    foreach (var col in columnmodel) { 
                    Console.WriteLine(col.Id+" "+col.HeaderName+" "+col.ImportSourceId);
                    }
*/
                    var deletequery = from col in _context.ColumnModel where col.ImportSourceId == id select col;
                    foreach (var data in deletequery)
                    {
                        _context.ColumnModel.Remove(data);


                    }
                    _context.ImportSource.Update(updateModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImportSourceExists(importSource.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(importSource);
        }

        // GET: ImportSources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ImportSource == null)
            {
                return NotFound();
            }

            var importSource = await _context.ImportSource
                .FirstOrDefaultAsync(m => m.Id == id);
            if (importSource == null)
            {
                return NotFound();
            }

            return View(importSource);
        }

        // POST: ImportSources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ImportSource == null)
            {
                return Problem("Entity set 'EntityFrameWork.ImportSource'  is null.");
            }
            var importSource = await _context.ImportSource.FindAsync(id);
            if (importSource != null)
            {
                _context.ImportSource.Remove(importSource);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImportSourceExists(int id)
        {
            return _context.ImportSource.Any(e => e.Id == id);
        }




        public IActionResult Product([Bind("id")] int id)
        {
            try
            {

                var columnlist = from col in _context.ColumnModel where col.ImportSourceId == id select col;
                /*var lcolumnlist = _context.CustomModel.Where(col => col.ColumnModel.ImportSourceId == id);*/

                var importsource = from col in _context.ImportSource where col.Id == id select col;
                var query = "select column_name as Id from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME ='ProductTable' and not column_name='Id' and not column_name='ImportSourceId'";
                //var query = "select * from /*ImportSource*/";


                var connection = _Dcontext.CreateConnection();
                var column = connection.Query<string>(query);


                //SelectListItem dropdown = new SelectListItem { }
                CustomModel model = new CustomModel();
                model.ImportSource = importsource.ToList();
                model.ColumnModel = columnlist.ToList();
                List<ListDropDown> drop = new List<ListDropDown>();
                foreach (var item in column)
                {
                    drop.Add(new ListDropDown() { Text = item, Value = item });
                }
                model.ListDropDowns = drop;
                return View(model);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public IActionResult Save([Bind("data")] string data, [Bind("id")] int id) {
            List<ProductMapValue> dict = JsonConvert.DeserializeObject<List<ProductMapValue>>(data);
            for (int i=0; i < dict.Count(); i++)
            {
                dict[i].ImportSourceId = id;
            }
            
            dict = dict.Where(x => x.ProductHeader != "").ToList();
            
            var connection = _Dcontext.CreateConnection();


            /*_context.ProductMapValue.Add(dict[0]);
            _context.SaveChanges();*/


            /*            
                        for (int i = 0; i < dict.Count(); i++)
                        {
                            parameters.Add("k", dict[i].key);
                            parameters.Add("v", dict[i].value);
                            var queryadd = @"insert into maptable(ColumnId,ProductHeader) values (@k,@v)";
                            connection.Execute(queryadd,parameters);
                        }*/


            //Bulkinsert
            DapperPlusManager.Entity<ProductMapValue>().Table("ProductMapValue");
            connection.BulkInsert(dict);








            //create map table in database




            //create model in c#.


            //prepare data to model.
            //Store data to table.

            return RedirectToAction(nameof(Index));
        }
        public IActionResult DataInsert([Bind("Id")]int id)
        {
            //Getting TableData
            ImportSource importsource = _context.ImportSource.Find(id);
            var stringdata = importsource.TableData;
            List<List<string>> tabledata = JsonConvert.DeserializeObject<List<List<string>>>(stringdata);


            var  maptable = from x in _context.ProductMapValue where x.ImportSourceId == id select x;
            List<ProductMapValue> maptablelist = maptable.ToList();
            List<string> productheader = new();
            List<int> columnid = new();
            foreach(var item in maptablelist)
            {
                productheader.Add(item.ProductHeader);
                columnid.Add(item.ColumnId);

            }
            List<string> mappedcolumnname = new();

            foreach (var i in columnid)
            {
                var columnname = (from x in _context.ColumnModel where x.Id == i select x.HeaderName).ToList();
                mappedcolumnname.Add(columnname[0]);
            }

            
            

            


            /*            int columnid = maptable[0].ColumnId;
            */            //Query data into datatable


            var firstrow = tabledata[0];


            DataTable table = new DataTable();
            for (int i = 0; i < firstrow.Count(); i++)
            {
                table.Columns.Add(firstrow[i]);
            }


            for (int i = 1; i < tabledata.Count(); i++)
            {
                DataRow row = table.NewRow();
                var rows = tabledata[i];

                for (int j = 0; j < firstrow.Count(); j++) {

                    row[firstrow[j]] = rows[j];

                }
                table.Rows.Add(row);


            }

            
            foreach (DataRow r in table.Rows) {
                Console.WriteLine("\n");
                foreach (var c in mappedcolumnname) {
                    Console.WriteLine(c + "=" + r[c]);

                }
            }

            var listofheaders = productheader.Zip(mappedcolumnname, (p, m) => new { ProductName=p, MappedName=m });
            List<ProductTable> listproduct = new();
            foreach (DataRow r in table.Rows)
            {
                ProductTable product = new ProductTable();
                product.ImportSourceId = id;
                foreach (var c in listofheaders) {
                    string productmap = c.ProductName;

                    string mapcolumn = r[c.MappedName].ToString();
                    if (productmap =="ProductId"){
                        product.ProductId = mapcolumn;
                    }
                    if (productmap == "Link")
                    {
                        product.Link = mapcolumn;
                    }
                    if (productmap == "Title")
                    {
                        product.Title = mapcolumn;
                    }
                    if (productmap == "Description")
                    {
                        product.Description = mapcolumn;
                    }
                    if (productmap == "Price")
                    {
                        double price = double.Parse(mapcolumn);
                        product.Price = price;
                    }
                    if (productmap == "SalePrice")
                    {
                        double price = 0;
                        if (mapcolumn == "")
                        {
                            price = product.Price;
                        }
                        else {
                            price = double.Parse(mapcolumn);
                        }
                        
                        product.SalePrice = price;

                    }
                    if (productmap == "ImageLink")
                    {
                        product.ImageLink = mapcolumn;
                    }
                    if (productmap == "Brand")
                    {
                        product.Brand = mapcolumn;
                    }
                    if (productmap == "Color")
                    {
                        product.Color = mapcolumn;
                    }
                    if (productmap == "Size")
                    {
                        product.Size = mapcolumn;
                    }


                }

                listproduct.Add(product);

            }


            /*foreach (DataRow r in table.Rows) {
                    product.ImportSourceId = id;
                int i = 0;
                var mappedcolumnname[i]="";
                for (int i=0; i < mappedcolumnname.Count(); i++) {
                    for(in)
                    product.ProductId = r[(mappedcolumnname[i])];
                    product.Link = r[(mappedcolumnname[i])];
                    product.Title =;
                    product.Description =;
                    product.Price =;
                    product.SalePrice =;
                    product.ImageLink =;
                    product.Brand =;
                    product.Color =;
                    product.Size =;
                    
                }


            }*/
            /*foreach (DataRow r in table.Rows) {
                Console.WriteLine("\n");
                foreach (DataColumn c in table.Columns) {
                    Console.WriteLine(c +" =" + r[c]);
                   
                }
                
            }*/
            //Prepared all data to model from excel sheet
            //Select Columns from Map table with respect to current store and importsourceid.
            //Filter those data only coming from map table column.
            //Insert into product table

            /* _context.ProductTable.Add(product);
             _context.SaveChanges();*/

            var connection = _Dcontext.CreateConnection();
            connection.BulkInsert(listproduct);





            return View();
        }

        public IActionResult Data()
        {
            List<ProductTable> data = (from col in _context.ProductTable select col).ToList();
            return View(data);
        }
    }
    
}