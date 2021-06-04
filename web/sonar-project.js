const sonarqubeScanner = require('sonarqube-scanner')

sonarqubeScanner(
  {
    serverUrl: 'http://localhost:9000',
    token: 'fb6cef76d37c7196041fbc4c27df1ffa315eaa72',
    options: {
      'sonar.projectKey': 'React',
      'sonar.projectName': 'React',
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
