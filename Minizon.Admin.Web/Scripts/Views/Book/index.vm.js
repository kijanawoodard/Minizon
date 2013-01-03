/// <reference path="../../jquery-1.8.3.intellisense.js" />
/// <reference path="../../knockout-2.2.0.debug.js" />
/// <reference path="../../knockout.mapping-latest.debug.js" />

var App = App || {};

$(function (App, $, ko) {
    "use strict";

    App.catalogService = {
        getAllBooks: function(callback) {
            $.ajax({
                url: '/api/catalog',
                type: 'get',
                dataType: 'json',
                contentType: 'application/json',
                success: function(response) {
                    callback(response);
                },
                error: function(response) {
                    console.log(response);
                }
            });
        }
    };
    
    App.pricingService = {
        createPricing: function (pricing) {
            $.ajax({
                url: '/api/pricing',
                type: 'post',
                dataType: 'json',
                contentType: 'application/json',
                data: pricing,
                success: function (response) {
                    console.log(response);
                },
                error: function (response) {
                    console.log(response);
                }
            });
        }
    };

    App.aBookViewModel = function (isbn, name, author, suggestedPrice, ourPrice) {
        var self = this;
        self.isbn = ko.observable(isbn);
        self.name = ko.observable(name);
        self.author = ko.observable(author);
        self.suggestedPrice = ko.observable(suggestedPrice);
        self.ourPrice = ko.observable(ourPrice);
    };

    App.indexBookViewModel = function() {
        var books;
        App.catalogService.getAllBooks(function (data) {
            books = ko.mapping.fromJS(data);
        });
            
        return {
            books: books
        };
    }();

    ko.applyBindings(App.indexBookViewModel);
}(App, jQuery, ko));