/// <reference path="../../Lib/angular-1.5.8.js" />

(function () {       

    'use strict';
    
    var configFn = function ($stateProvider, $urlRouterProvider) {

        // Default Url, if any URL not match, redirect to it
        $urlRouterProvider.otherwise('/Admin/bookCategory/List');

        $stateProvider
            .state("book_category_add", {
                url: '/Admin/bookCategory/Create',
                templateUrl: 'Areas/Admin/templates/views/book_category/Create.html',
                controller: 'bookCategory_create'
            })
            .state("book_category_list", {
                url: '/Admin/bookCategory/List',
                templateUrl: 'Areas/Admin/templates/views/book_category/List.html',
                controller: 'bookCategory_list'
            })
            .state("book_create", {
                 url: '/Admin/book/Create',
                 templateUrl: 'Areas/Admin/templates/views/books/Create.html',
                 controller: 'book_create'
             })
            .state("book_edit", {
                 url: '/Admin/book/Edit/{bookId:int}',
                 templateUrl: 'Areas/Admin/templates/views/books/Create.html',
                 controller: 'book_create'
             })
            .state("book_list", {
                url: '/Admin/book/List',
                templateUrl: 'Areas/Admin/templates/views/books/List.html',
                controller: 'book_list',
            })
            .state("dispatch_printLabel", {
                 url: '/Admin/dispatch/printlabel',
                 templateUrl: 'Areas/Admin/templates/views/dispatch/printLabel.html',
                 controller: 'dispatch_printLabel',
             })
            .state("dispatch_addWheight", {
                url: '/Admin/dispatch/wheight',
                templateUrl: 'Areas/Admin/templates/views/dispatch/wheight.html',
                controller: 'dispatch_addWheight',
            })
            .state("dispatch_addConsignment", {
             url: '/Admin/dispatch/consignment',
             templateUrl: 'Areas/Admin/templates/views/dispatch/consignment.html',
             controller: 'dispatch_addConsignment',
            })
            .state("coupon_list", {
                url: '/Admin/Coupons',
                templateUrl: 'Areas/Admin/templates/views/Coupons.html',
                controller: 'coupons_list',
            })
            .state("bundle_list", {
                url: '/Admin/bookBundle/List',
                templateUrl: 'Areas/Admin/templates/views/boookBundle/List.html',
                controller: 'bundle_list',
            })
            .state("bundle_create", {
                url: '/Admin/bookBundle/Create',
                templateUrl: 'Areas/Admin/templates/views/boookBundle/Create.html',
                controller: 'bundle_create',
                controllerAs: 'bundleInfo'
            })
            .state("bundle_edit", {
                url: '/Admin/bookBundle/Edit/{bundleId:int}',
                templateUrl: 'Areas/Admin/templates/views/boookBundle/Create.html',
                controller: 'bundle_create',
                controllerAs: 'bundleInfo'
            })
            .state("quiz_create", {
                url: '/Admin/Quiz/Create',
                templateUrl: 'Areas/Admin/templates/views/QuizQuestions/Create.html',
                controller: 'quiz_create'
            })
            .state("quiz_list", {
                url: '/Admin/Quiz/List',
                templateUrl: 'Areas/Admin/templates/views/QuizQuestions/List.html',
                controller: 'quiz_list',
            })
        .state("quiz_edit", {
            url: '/Admin/Quiz/Edit/{quizId:int}',
            templateUrl: 'Areas/Admin/templates/views/QuizQuestions/Create.html',
            controller: 'quiz_create'
        })
        ;

    }

    var moduleDependencies =
        [
            'datatables',
            'uiSwitch',             // https://github.com/xpepermint/angular-ui-switch
            'Silverzone_app.Common'
        ];

    angular.module('Silverzone_app', moduleDependencies)
    .config(['$stateProvider', '$urlRouterProvider', configFn])
    ;

   
})();