import { fileURLToPath, URL } from 'node:url';

import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-react';
import fs from 'fs';
import path from 'path';
import child_process from 'child_process';

const baseFolder =
      process.env.APPDATA !== undefined && process.env.APPDATA !== ''
        ? `${process.env.APPDATA}/ASP.NET/https`
        : `${process.env.HOME}/.aspnet/https`;

const certificateArg = process.argv.map(arg => arg.match(/--name=(?<value>.+)/i)).filter(Boolean)[0];
const certificateName = certificateArg ? certificateArg.groups.value : "restaurantprojectwebsite.client";

if (!certificateName) {
    console.error('Invalid certificate name. Run this script in the context of an npm/yarn script or pass --name=<<app>> explicitly.')
    process.exit(-1);
}

const certFilePath = path.join(baseFolder, `${certificateName}.pem`);
const keyFilePath = path.join(baseFolder, `${certificateName}.key`);

if (!fs.existsSync(certFilePath) || !fs.existsSync(keyFilePath)) {
    if (0 !== child_process.spawnSync('dotnet', [
        'dev-certs',
        'https',
        '--export-path',
        certFilePath,
        '--format',
        'Pem',
        '--no-password',
    ], { stdio: 'inherit', }).status) {
        throw new Error("Could not create certificate.");
    }
}

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [plugin()],
    //resolve: {
    //    alias: {
    //        '@': fileURLToPath(new URL('./src', import.meta.url))
    //    }
    //},
    server: {
        proxy: {
            '/home': {
                target: 'http://127.0.0.1:5116/',
             
            },
    //        '/isAuth': {
    //            target: 'http://localhost:5001/',
          
    //        },
            '/register': {
                target: 'http://127.0.0.1:5116/',
               
            },
            '/login': {
                target: 'http://127.0.0.1:5116/',  
            },
    //        '/loguot': {
    //            target: 'http://localhost:5116/',
               
    //        }
    //        //'^/weatherforecast': {
    //        //    target: 'https://localhost:5001/',
    //        //    secure: false
    //        //},
    //        //'^/weatherforecast': {
    //        //    target: 'https://localhost:5001/',
    //        //    secure: false
    //        //},
    //        //'^/weatherforecast': {
    //        //    target: 'https://localhost:5001/',
    //        //    secure: false
    //        //}         
        },
        host: "127.0.0.1",
        port: 8000,
        //https: {
        //    key: fs.readFileSync(keyFilePath),
        //    cert: fs.readFileSync(certFilePath),
        //}
    }
})
