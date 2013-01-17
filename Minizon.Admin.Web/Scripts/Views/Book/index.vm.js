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
                async:false,
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
        getAllPrices: function (callback) {
            $.ajax({
                url: '/api/pricing',
                type: 'get',
                dataType: 'json',
                contentType: 'application/json',
                success: function (response) {
                    callback(response);
                },
                error: function (response) {
                    console.log(response);
                }
            });
        }
    };

    App.aBookViewModel = function (id, isbn, name, author, suggestedPrice, ourPrice) {
        var self = this;
        self.id = id;
        self.isbn = ko.observable(isbn);
        self.name = ko.observable(name);
        self.author = ko.observable(author);
        self.suggestedPrice = ko.observable(suggestedPrice);
        self.ourPrice = ko.observable(ourPrice);
    };

    App.indexBookViewModel = function () {
        var books = ko.observableArray([]);

        App.catalogService.getAllBooks(function (data) {
            data.forEach(function (item) {
                books.push(new App.aBookViewModel(item.id, item.iSBN, item.name, item.author, item.suggestedPrice, 0));
            });
        });
        App.pricingService.getAllPrices(function (data) {
            ko.utils.arrayForEach(data, function(item) {
                console.log(item);
            });
            ko.utils.arrayForEach(data, function (item) {
                var foundBook = ko.utils.arrayFirst(books(), function (candidate) {
                    return candidate.id == item.bookId;
                });
                foundBook.ourPrice(item.price);
            });
        });
            
        return {
            books: books
        };
    }();

    ko.applyBindings(App.indexBookViewModel);
}(App, jQuery, ko));