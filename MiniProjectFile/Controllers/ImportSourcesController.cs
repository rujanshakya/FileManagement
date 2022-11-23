using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using MiniProjectFile.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace MiniProjectFile.Controllers
{
    public class ImportSourcesController : Controller
    {
        private readonly EntityFrameWork _context;

        public ImportSourcesController(EntityFrameWork context)
        {
            _context = context;
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
        public async Task<IActionResult> Create([Bind("Id,Name,FileName,FilePath,FileFormat,CreatedBy,CreatedOn")] ImportSource importSource, [Bind("Column")] string column, [Bind("TableData")]  string tabledata)
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
            
            
            
            foreach (var col in objectColumn) {
                Console.Write(col +"\n");
            }
/*            childModel.ImportSourceId = importSource.Id;
*//*            childModel.HeaderName = column;
*/            foreach (var col in objectColumn)
            {

                tempColumn.Add(new ColumnModel() { ImportSourceId=parentModel.Id, HeaderName=col });
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

                    updateModel.Columns= tempColumn;

                    /*var columnmodel = await _context.ColumnModel.FirstOrDefaultAsync(x => x.ImportSourceId == id);
                    _context.Remove(columnmodel);
                */
                    /*var columnmodel= await _context.ColumnModel.Where(x=>x.ImportSourceId== ).ToListAsync();
                    foreach (var col in columnmodel) { 
                    Console.WriteLine(col.Id+" "+col.HeaderName+" "+col.ImportSourceId);
                    }
*/
                    var deletequery = from col in _context.ColumnModel where col.ImportSourceId == id select col;
                    foreach (var data in deletequery) {
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
                    }                }
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
       
        //GET for Product
        public IActionResult Product(int id) {
            id = 89;
            var columnlist = from col in _context.CustomModel where col.ColumnModel.ImportSourceId == id select col;
/*            var lcolumnlist = _context.CustomModel.Where(col => col.ColumnModel.ImportSourceId == id);
*/
            var importsource = from col in _context.ImportSource where col.Id == id select col;
            return View(columnlist.ToList()) ;
        }

    }   
}
