const { ArgumentParser } = require('argparse');
const fs = require('fs-extra');

const glob = require("glob");
const path = require('path');
const { exit } = require('process');


const parser = new ArgumentParser({
  description: 'c# template template'
});

parser.add_argument('-n', '--name', { help: 'sets project name' });
parser.add_argument('-d', '--dest', { help: 'sets project destination' });
let args = parser.parse_args();

const replaceAllNames = function (src, fileMode) {
  glob(src + '/**/*', (err, res) => {
    if (err) {
      console.log('Error', err);
    } else {
      for (let r in res) {
        if (!fs.existsSync(res[r])) {
          continue;
        }
        if (fileMode) {
          if (fs.lstatSync(res[r]).isFile()) {
            const checkFile = fs.readFileSync(res[r], "utf-8").replaceAll("$ProjectName", `${args.name}`);
            fs.removeSync(res[r]);
            fs.writeFileSync(res[r].replaceAll("ProjectName", `${args.name}`), checkFile);
          }
        } else if (fs.lstatSync(res[r]).isDirectory() && res[r].includes("ProjectName")) {
          fs.renameSync(res[r], res[r].replaceAll("ProjectName", args.name));
        }
      }
    }
  });
};

if (!args.name || !args.dest) {
  console.log("Missing required parameters");
  exit(1)
}

fs.copy(`./`, `${args.dest}/${args.name}.Solution`);
setTimeout(() => {
  replaceAllNames(`${args.dest}/${args.name}.Solution`, false);
  setTimeout(() => {
    replaceAllNames(`${args.dest}/${args.name}.Solution`, true);
  }, 2000);
}, 500);