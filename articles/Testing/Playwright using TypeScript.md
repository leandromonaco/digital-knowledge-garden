## Prerequisites

- Node.js version 12 or above. See [[Install multiple NodeJS Versions]]
## Installation

https://vitalets.github.io/playwright-bdd/#/getting-started/installation
https://playwright.dev/docs/intro

_Run from your project's root directory_  

```
   npm init playwright@latest (if new project)
```

√ Do you want to use TypeScript or JavaScript? · `TypeScript`
√ Where to put your end-to-end tests? · `tests`
√ Add a GitHub Actions workflow? (y/N) · `true`
√ Install Playwright browsers (can be done manually via `npx playwright install`)? (Y/n) · `true`

```
npm i -D playwright@latest (if existing project)
npm i -D @cucumber/cucumber@latest
npm i -D playwright-bdd@latest
```

## Running the Example Test

By default tests will be run on all 3 browsers, chromium, firefox and webkit using 3 workers. This can be configured in the [playwright.config file](https://playwright.dev/docs/test-configuration). Tests are run in headless mode meaning no browser will open up when running the tests. Results of the tests and test logs will be shown in the terminal.

```
npx playwright test
```

To open last HTML report run:

`npx playwright show-report`

## Playwright Configuration
Add the following to `playwright.config.ts in the project root:

```typescript
import { defineConfig, devices } from '@playwright/test';
import { defineBddConfig } from 'playwright-bdd';

const testDir = defineBddConfig({
  paths: ['features/**/*.feature'],
  require: ['steps/**/*.ts'],
});

/**
 * Read environment variables from file.
 * https://github.com/motdotla/dotenv
 */
// require('dotenv').config();

/**
 * See https://playwright.dev/docs/test-configuration.
 */

export default defineConfig({
  testDir,
  /* Run tests in files in parallel */
  fullyParallel: true,
  /* Fail the build on CI if you accidentally left test.only in the source code. */
  forbidOnly: !!process.env.CI,
  /* Retry on CI only */
  retries: process.env.CI ? 2 : 0,
  /* Opt out of parallel tests on CI. */
  workers: process.env.CI ? 1 : undefined,
  /* Reporter to use. See https://playwright.dev/docs/test-reporters */
  reporter: 'html',
  /* Shared settings for all the projects below. See https://playwright.dev/docs/api/class-testoptions. */
  use: {
    /* Base URL to use in actions like `await page.goto('/')`. */
    // baseURL: 'http://127.0.0.1:3000',
    /* Collect trace when retrying the failed test. See https://playwright.dev/docs/trace-viewer */
    trace: 'on-first-retry',
    /*Show brownser*/
    headless: false
  },
  /* Configure projects for major browsers */
  projects: [
    {
      name: 'chromium',
      use: { ...devices['Desktop Chrome'] },
    },
    {
      name: 'firefox',
      use: { ...devices['Desktop Firefox'] },
    },  
    {
      name: 'webkit',
      use: { ...devices['Desktop Safari'] },
    },
    /* Test against mobile viewports. */
    // {
    //   name: 'Mobile Chrome',
    //   use: { ...devices['Pixel 5'] },
    // },
    // {
    //   name: 'Mobile Safari',
    //   use: { ...devices['iPhone 12'] },
    // },
    /* Test against branded browsers. */
    // {
    //   name: 'Microsoft Edge',
    //   use: { ...devices['Desktop Edge'], channel: 'msedge' },
    // },
    // {
    //   name: 'Google Chrome',
    //   use: { ...devices['Desktop Chrome'], channel: 'chrome' },
    // },
  ],

  /* Run your local dev server before starting the tests */
  // webServer: {
  //   command: 'npm run start',
  //   url: 'http://127.0.0.1:3000',
  //   reuseExistingServer: !process.env.CI,
  // },

});
```

## Create BDD Test

Create `features/test.feature`
https://vitalets.github.io/playwright-bdd/#/writing-features/index
https://vitalets.github.io/playwright-bdd/#/writing-features/special-tags
https://vitalets.github.io/playwright-bdd/#/writing-features/customize-examples-title
```
Feature: Playwright site
  
    Scenario: Check title
        Given I open url "https://playwright.dev"
        When I click link "Get started"
        Then I see in title "Playwright"
```

Run `npx bddgen` to generate Step Definition Code Snippet

Copy snippet into `steps/test.ts`

```
import { createBdd } from 'playwright-bdd';

const { Given, When, Then } = createBdd();

// 1. Missing step definition for "features\test.feature:4:9"
Given('I open url {string}', async ({}, arg) => {
  // ...
});

// 2. Missing step definition for "features\test.feature:5:9"
When('I click link {string}', async ({}, arg) => {
  // ...
});

// 3. Missing step definition for "features\test.feature:6:9"
Then('I see in title {string}', async ({}, arg) => {
  // ...
});
```


Add `import { expect } from '@playwright/test';` to `steps/test.ts`

Record Playwright Test

Copy code into Step definition

```
import { createBdd } from 'playwright-bdd';
import { expect } from '@playwright/test';  

const { Given, When, Then } = createBdd();

Given('I open url {string}', async ({ page }, url) => {
    await page.goto(url);
});

When('I click link {string}', async ({ page }, name) => {
    await page.getByRole('link', { name }).click();
});

Then('I see in title {string}', async ({ page }, keyword) => {
    await expect(page).toHaveTitle(new RegExp(keyword));
});
```

## Run Tests
Run `npx bddgen` to generate step definition template under `.features-gen\features\` folder (**each time feature file changes this is required**)

Run all tests
```powershell
npx playwright test
```
Run only tagged tests
```powershell
npx playwright test --grep "@login"
```
Run with UI Mode (for troubleshooting)
```
npx playwright test --ui
```


https://semaphoreci.com/blog/flaky-tests-playwright