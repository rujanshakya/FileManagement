var save = document.getElementById('btnSave');
var source = document.getElementsByClassName('Icolumn');
var dest = document.getElementsByClassName('Tcolumn');
var input = document.getElementById('data')
var data = []
save.addEventListener('click', () => {
    data = [];
    for (let i = 0; i < source.length; i++) {
        console.log(source[i].value)
        var _source = source[i].value;
        var _dest = dest[i].value;
        var dict = { key: _source, value: _dest }
        data.push(dict);

    }
    console.log(data);
    var datastring = JSON.stringify(data);
    console.log(datastring);
    input.value = datastring;
});
/*
function Save() {
    var data = [];
    for (let i = 0; i < source.length; i++) {
        console.log(source[i].value)
      var _source = source[i].value;
        var _dest = dest[i].value;
        var dict = { key: _source, value: _dest }
        data.push(dict);
            
  }
    console.log(data);
    var datastring = JSON.stringify(data);
    input.value = datastring;
};*/