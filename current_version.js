
var fs = require('fs');

const commit = process.argv[2];
const option = process.argv[3];

function getCurrentVersion() {
  const data = fs.readFileSync('./app/package.json', 'utf8');
  const currentVersion = JSON.parse(data);
  return currentVersion.version;
}

function getVersionFragment() {
  if (commit.includes('beta:')) {
    return 'beta';
  }
  if (commit.includes('release:')) {
    return 'release';
  }
  if (commit.includes('major:')) {
    return 'major';
  }
  if (commit.includes('bug:')) {
    return 'bug';
  }
  if (commit.includes('alpha:')) {
    return 'alpha';
  }
  if (commit.includes('rc:')) {
    return 'rc';
  }
  return 'beta';
}

if (option === 'current_version') {
  console.log(`current_version=${getCurrentVersion()}`);
}

if (option === 'version_fragment') {
  console.log(`version_fragment=${getVersionFragment()}`);
}
