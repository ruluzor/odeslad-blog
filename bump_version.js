const fs = require('fs');
const { json2xml } = require('xml-js');
const xml2js = require('xml2js');

const parser = new xml2js.Parser();
const version = process.argv[2];

function updateAppFiles() {
  const data = fs.readFileSync('./app/package.json', 'utf8');
  let document = JSON.parse(data);
  document.version = version;
  fs.writeFileSync('./app/package.json', JSON.stringify(document, null, 2));

  const dataLock = fs.readFileSync('./app/package-lock.json', 'utf8');
  let documentLock = JSON.parse(dataLock);
  documentLock.version = version;
  fs.writeFileSync('./app/package-lock.json', JSON.stringify(documentLock, null, 2));
}

async function updateApiFiles() {
  const data = fs.readFileSync('./api/api.csproj', 'utf8');
  parser.parseString(data, function(error, result) {
    if(error === null) {
      result.Project.PropertyGroup[0].Version[0] = version;
      let builder = new xml2js.Builder();
      let xml = builder.buildObject(result);
      fs.writeFileSync('./api/api.csproj', xml);
    }
    else {
      console.log(error);
    }
  });
}

updateAppFiles();
updateApiFiles();