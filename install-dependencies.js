const { spawn } = require('child_process');
const path = require('path');
const fs = require('fs');

// Function to install dependencies if the directory exists
const installDependencies = (projectPath, projectName) => {
  return new Promise((resolve, reject) => {
    if (fs.existsSync(projectPath)) {
      console.log(`Installing dependencies for ${projectName}...`);
      const process = spawn('npm', ['install'], {
        cwd: projectPath,
        stdio: 'inherit',
        shell: true
      });

      process.on('close', (code) => {
        if (code === 0) {
          console.log(`${projectName} dependencies installed successfully.`);
          resolve();
        } else {
          console.error(`Error installing ${projectName} dependencies. Exit code: ${code}`);
          reject(new Error(`Failed to install dependencies for ${projectName}`));
        }
      });
    } else {
      console.error(`Directory ${projectPath} does not exist.`);
      reject(new Error(`Directory ${projectPath} does not exist.`));
    }
  });
};

(async () => {

  const nextPath = path.resolve(__dirname, 'src/rida.NextApp');
  try {
    await installDependencies(nextPath, 'Next.js app');
  } catch (error) {
    console.error(`Failed to install dependencies for Next.js app: ${error.message}`);
  }
})();
