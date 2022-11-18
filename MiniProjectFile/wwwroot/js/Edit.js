var inputFile = document.getElementById('file');
var _dataArray = [];
var _dataColumn = [];

inputFile.addEventListener('change', () => {
    //FileDetails Part
    var _name = document.getElementById('_name');
    var fileName = document.getElementById('fileName');
    var filePath = document.getElementById('filePath');
    var fileFormat = document.getElementById('fileFormat');
    var createdBy = document.getElementById('createdBy');
    var colarray = document.getElementById('columnarray');
    var currentFile = inputFile.files[0];
    var currentFileName = currentFile.name.split('.');
    _name.value = currentFileName[0];
    fileName.value = currentFile.name;
    filePath.value = inputFile.value;
    fileFormat.value = currentFileName[1];
    createdBy.value = createdBy.value;

    //FileInput Part
    var FileData = document.getElementById('FileData');
    readXlsxFile(inputFile.files[0]).then((d) => {
        var dataArray = d;
        _dataArray = dataArray;
        var dataColumn = dataArray[0];
        _dataColumn.push(dataColumn);

        for (var i = 0; i < dataColumn.length; i++) {
            FileData.innerHTML += `<tr><td>${i + 1}</td><td>${dataColumn[i]}</td></tr>`;
        }
        console.log(_dataColumn);
        var fdataColumn = _dataColumn[0];
        var ColumnString = JSON.stringify(fdataColumn);
        colarray.value = ColumnString;
        /*document.ajax({
            type: "POST",
            traditional: true,
            url: "../ImportSource/Create/SaveTable",
            data: { function_param: _dataArray }
        });*/
        /*var file_data = JSON.stringify(_dataArray);
        var data_column = JSON.stringify(_dataColumn);
        console.log(file_data);*/
    });
    /*var columndata = dataArray[0];
   console.log(FileData);
   console.log(_dataColumn);
   console.log(_dataArray);*/


});




