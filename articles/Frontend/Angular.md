# Training

Introduction to Angular: [Codelab](https://codelabs.developers.google.com/introduction-to-angular#0) | [Video](https://www.youtube.com/watch?v=qxchrt04bTA)

## Tools
  
  1. [[Angular]] 
  3. Install Angular Language Service for VS Code `code --install-extension angular.ng-template`

## Create a new Angular App

1. Run ```ng new NewApp.UI --strict false```
2. Would you like to add Angular routing? ```Yes```
3. Which stylesheet format would you like to use? ```CSS```
4. Navigate to the NewApp.UI folder
5. Run ```ng serve``` (Angular Development Server)

```

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `-prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Install Dependencies

Run ```npm install```

By default, it will install all modules listed as dependencies in the ```package.json``` file.

https://docs.npmjs.com/cli/v6/commands/npm-install

## Generate Library

https://angular.io/guide/creating-libraries

1. ng new my-workspace --no-create-application
2. cd my-workspace
3. ng generate library my-lib

## Generate Component

https://angular.io/tutorial/toh-pt3

```ng generate component user-card```

https://github.com/leandromonaco/Workbench/commit/b50ce6b655b6f1747ee6d313955eef228584cf6d

![WindowsTerminal_Rd9hoeuAXP](https://user-images.githubusercontent.com/5598150/168176658-34820f94-c3c4-4c77-a934-add63b8720aa.gif)

## Documentation

- [NPM CLI Commands](https://docs.npmjs.com/cli/v8/commands)
- [Angular CLI Commands](https://angular.io/cli/)

## Angular CLI

  > The latest [[Install multiple NodeJS Versions]] version is recommended
  
  1. Run `npm install -g @angular/cli@13.3.10` or `npm install -g @angular/cli@latest`
  2. Run `ng --version`