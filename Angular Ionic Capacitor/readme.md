OF THE PAST NOT NEEDED ANYMORE

I need to build and get a dist folder so I can deploy angular to azure web app, but because of ionic capacitor i get different structure,
but I can't comment inside a json file so I do it here! 

"architect": {
        "build": {
          "builder": "@angular-devkit/build-angular:browser",
          "options": {
            "outputPath": "dist"
            // "outputPath": "www",
            // "index": "src/index.html",
            // "main": "src/main.ts",
            // "polyfills": "src/polyfills.ts",
            // "tsConfig": "tsconfig.app.json",
            // "inlineStyleLanguage": "scss",
            // "assets": [
            //   {
            //     "glob": "**/*",
            //     "input": "src/assets",
            //     "output": "assets"
            //   },
            //   {
            //     "glob": "**/*.svg",
            //     "input": "node_modules/ionicons/dist/ionicons/svg",
            //     "output": "./svg"
            //   }
            // ],
            // "styles": ["src/global.scss", "src/theme/variables.scss"],
            // "scripts": []
          },
