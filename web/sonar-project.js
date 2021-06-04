const sonarqubeScanner = require('sonarqube-scanner')

sonarqubeScanner(
  {
    serverUrl: '<url sonarquebe>',
    token: '<token>',
    options: {
      'sonar.projectKey': '<projectKey>',
      'sonar.projectName': '<projectName>',
      'sonar.exclusions':
        './node_modules/**,src/environments/**,**/*.spec.ts,dist/**,**/docs/**,**/*.js,e2e/**,coverage/**,TLH-distributions/**,src/bsb-theme/css/**',
      'sonar.sources': './src',
      'sonar.tests': './src/__tests__',
      'sonar.test.inclusions': './src/**/*.test.ts,src/**/*.test.tsx',
      'sonar.typescript.lcov.reportPaths': 'coverage/lcov.info',
      'sonar.testExecutionReportPaths': 'reports/test-report.xml',
    },
  },
  () => {}
)
