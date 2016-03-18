var gulp = require("gulp");
var msbuild = require("gulp-msbuild");
var debug = require("gulp-debug");
var runSequence = require("run-sequence");
var foreach = require("gulp-foreach");

var config = require("./gulp-config.js")();
module.exports.config = config;



/*****************************
  Initial setup
*****************************/

gulp.task("02-Publish-All-Projects", function (callback) {
    runSequence(
      "Publish-Feature-Projects",
      callback);
});


/*****************************
  Publish
*****************************/
var publishProjects = function (location, dest) {
    dest = dest || config.websiteRoot;
    console.log("publish to " + dest + " folder");
    return gulp.src([location + "/**/*.csproj"])
      .pipe(foreach(function (stream, file) {
          return stream
            .pipe(debug({ title: "Building project:" }))
            .pipe(msbuild({
                targets: ["Build"],
                configuration: config.buildConfiguration,
                logCommand: false,
                verbosity: "minimal",
                maxcpucount: 0,
                toolsVersion: 14.0,
                properties: {
                    DeployOnBuild: "true",
                    DeployDefaultTarget: "WebPublish",
                    WebPublishMethod: "FileSystem",
                    DeleteExistingFiles: "false",
                    publishUrl: dest,
                    _FindDependencies: "false"
                }
            }));
      }));
};

gulp.task("Publish-Feature-Projects", function () {
    return publishProjects("./src/Features");
});

/*****************************
 Watchers
*****************************/
gulp.task("Auto-Publish-Css", function () {
  var root = "./src";
  var roots = [root + "/**/assets", "!" + root + "/**/obj/**/assets"];
  var files = "/*.css";
  var destination = config.websiteRoot + "\\assets";
  gulp.src(roots, { base: root }).pipe(
    foreach(function (stream, rootFolder) {
      gulp.watch(rootFolder.path + files, function (event) {
        if (event.type === "changed") {
          console.log("publish this file " + event.path);
          gulp.src(event.path, { base: rootFolder.path }).pipe(gulp.dest(destination));
        }
        console.log("published " + event.path);
      });
      return stream;
    })
  );
});

gulp.task("Auto-Publish-Views", function () {
  var root = "./src";
  var roots = [root + "/**/Views", "!" + root + "/**/obj/**/Views"];
  var files = "/**/*.cshtml";
  var destination = config.websiteRoot + "\\Views";
  gulp.src(roots, { base: root }).pipe(
    foreach(function (stream, rootFolder) {
      gulp.watch(rootFolder.path + files, function (event) {
        if (event.type === "changed") {
          console.log("publish this file " + event.path);
          gulp.src(event.path, { base: rootFolder.path }).pipe(gulp.dest(destination));
        }
        console.log("published " + event.path);
      });
      return stream;
    })
  );
});