
using CompanyA.Reporting;
using CompanyB.Analytics;

CompanyA.Reporting.Report reportingReport = new CompanyA.Reporting.Report();
CompanyB.Analytics.Report analyticsReport = new CompanyB.Analytics.Report();

reportingReport.Generate();
analyticsReport.Generate();