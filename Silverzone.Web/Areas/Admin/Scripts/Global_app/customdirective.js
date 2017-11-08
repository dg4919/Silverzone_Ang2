/// <reference path="C:\dg4919_tfs\silverzoneLatest\Silverzone.Web\Scripts/Lib/angularjs/angular-1.5.0.js" />

(function (app) {
    'use strict';

    angular.module('Silverzone_app')
        .directive("addBookContentHtml", ['$compile', function ($compile) {       // if wee don't provide dependency as array will throw error after minification of JS

            var linker = function (scope, elem, attrs) {

                elem.bind("click", function () {

                    // just use as normal sing;le string & '\' use for a new line
                    var html = ' <div class="form-group col-sm-12" style="margin-top: 15px;"> <div class="col-sm-4"> \
                         <input type="text" placeholder="Book Content Name" class="form-control bookContent_name"> </div> \
                         <div class="col-sm-7"> \
                         <textarea placeholder="Enter Book Content Description" class="form-control bookContent_description" rows="2"></textarea>  </div> \
 	   		             <div class="col-sm-1" style="margin-top: 10px;"> \
				         <a href="#" class="btn btn-default btn-sm" ng-click="remove($event)"> Remove </a> </div> </div>'


                    angular.element(elem)
                        .parents('#book_ContentDv')
                        .append($compile(html)(scope));
                });
            }

            return {
                restrict: 'A',
                link: linker,
                controller: ['$scope', function ($sc) {
                    $sc.remove = function (elem) {

                        // use like jquery
                        angular.element(elem.currentTarget)
                            .parents('.form-group.col-sm-12')
                            .remove();
                    }
                }]
            }

        }])
        .directive("editBookContentHtml", ['$compile', function ($compile) {       // if wee don't provide dependency as array will throw error after minification of JS

            var linker = function (scope, elem, attrs) {

                var html = '';
                var contentModel = angular.copy(scope.bookContent_model);       // copy Data > so that don't change directly in main object

                angular.forEach(contentModel, function (entity, key) {
                    if (key != 0) {
                        html += ' <div class="form-group col-sm-12" style="margin-top: 15px;"> <div class="col-sm-4">'
                            + ' <input type="text" placeholder="Book Content Name" class="form-control bookContent_name" value="' + entity.Name + '"> </div>'
                            + ' <div class="col-sm-7">'
                            + ' <textarea placeholder="Enter Book Content Description" class="form-control bookContent_description" rows="2">' + entity.Description + '</textarea>  </div>'
                            + ' <div class="col-sm-1" style="margin-top: 10px;">'
                            + ' <a href="#" class="btn btn-default btn-sm" ng-click="remove($event)"> Remove </a> </div> </div>'
                    }
                });

                //angular.element(elem)
                //    .html($compile(html)(scope));

                angular.element(elem)
                    .replaceWith($compile(html)(scope));

            }

            return {
                restrict: 'E',
                scope: {
                    bookContent_model: '=model'
                },
                link: linker,
                controller: ['$scope', function ($sc) {
                    $sc.remove = function (elem) {
                        // use like jquery
                        angular.element(elem.currentTarget)
                            .parents('.form-group.col-sm-12')
                            .remove();
                    }
                }]
            }

        }])

        .directive("fileUploader", ['admin_quiz_Service', function (svc) {       // if wee don't provide dependency as array will throw error after minification of JS

            var linker = function (scope, elem, attrs, ctrl) {

                // to open a file dialog on click of btn :)
                angular.element(elem)
                       .find('a')
                       .on('click', function () {
                           angular.element(this)
                                  .next()
                                  .click();
                       });

                // file upload event code
                angular.element(elem)           // find content inside the directive DIV body
                       .find('#img_dialog')
                       .on('change', function (event) {
                           var target = angular.element(this).parent();

                           // var type = parseInt(attrs.type);      // to get attribute value attached with directive
                              var files = event.target.files;

                           if (files.length > 0) {
                               svc.upload_quizImage(files).then(function (data) {
                                   target.children().eq(0).attr('src', data.result[0]);

                                   //var value = ctrl.$modelValue;   // if want value of ngModel > scope obj value

                                   // contain the ngModel value OR we can direct set value into it
                                   ctrl.$setViewValue(data.result[0]);
                                   ctrl.$render();      // save new value

                                   // if we r binding an html inside Link fx
                                   //scope.$apply(); // needed if other parts of the app need to be updated
                               });
                           }
                       });
            }

            return {
                require: 'ngModel',
                restrict: 'A',
                //scope: {
                //    quiz: '=',        // this will be added into the link > scope
                //    type: "=",       // 2 way binding will return value as integer (required)
                //    index: "@",     // 1 way binding > return index integer value as string
                //},
                link: linker,
                templateUrl: 'view/quizImages.html'
            }

        }])

    ;

})();