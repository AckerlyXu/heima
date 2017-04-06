<properties
    pageTitle="Use MongoDB APIs to build a DocumentDB app | Azure"
    description="A NoSQL tutorial that creates an online database using the DocumentDB APIs for MongoDB."
    keywords="mongodb examples"
    services="documentdb"
    author="AndrewHoh"
    manager="jhubbard"
    editor=""
    documentationcenter="" />
<tags
    ms.assetid="fb38bc53-3561-487d-9e03-20f232319a87"
    ms.service="documentdb"
    ms.workload="data-services"
    ms.tgt_pltfrm="na"
    ms.devlang="na"
    ms.topic="article"
    ms.date="03/06/2017"
    wacn.date=""
    ms.author="anhoh" />

# Build a DocumentDB: API for MongoDB app using Node.js
> [AZURE.SELECTOR]
- [.NET](/documentation/articles/documentdb-get-started/)
- [.NET Core](/documentation/articles/documentdb-dotnetcore-get-started/)
- [Java](/documentation/articles/documentdb-java-get-started/)
- [Node.js for MongoDB](/documentation/articles/documentdb-mongodb-samples/)
- [Node.js](/documentation/articles/documentdb-nodejs-get-started/)
- [C++](/documentation/articles/documentdb-cpp-get-started/)

This example shows you how to build a DocumentDB: API for MongoDB console app using Node.js.

To use this example, you must:

- [Create](/documentation/articles/documentdb-create-mongodb-account/) an Azure DocumentDB: API for MongoDB account.
- Retrieve your MongoDB [connection string](/documentation/articles/documentdb-connect-mongodb-account/) information.

## Create the app

1. Create a *app.js* file and copy & paste the code below.

	nodejs

	    var MongoClient = require('mongodb').MongoClient;
	    var assert = require('assert');
	    var ObjectId = require('mongodb').ObjectID;
	    var url = 'mongodb://<endpoint>:<password>@<endpoint>.documents.azure.com:10250/?ssl=true';

	    var insertDocument = function(db, callback) {
	    db.collection('families').insertOne( {
	            "id": "AndersenFamily",
	            "lastName": "Andersen",
	            "parents": [
	                { "firstName": "Thomas" },
	                { "firstName": "Mary Kay" }
	            ],
	            "children": [
	                { "firstName": "John", "gender": "male", "grade": 7 }
	            ],
	            "pets": [
	                { "givenName": "Fluffy" }
	            ],
	            "address": { "country": "USA", "state": "WA", "city": "Seattle" }
	        }, function(err, result) {
	        assert.equal(err, null);
	        console.log("Inserted a document into the families collection.");
	        callback();
	    });
	    };
    
	    var findFamilies = function(db, callback) {
	    var cursor =db.collection('families').find( );
	    cursor.each(function(err, doc) {
	        assert.equal(err, null);
	        if (doc != null) {
	            console.dir(doc);
	        } else {
	            callback();
	        }
	    });
	    };
    
	    var updateFamilies = function(db, callback) {
	    db.collection('families').updateOne(
	        { "lastName" : "Andersen" },
	        {
	            $set: { "pets": [
	                { "givenName": "Fluffy" },
	                { "givenName": "Rocky"}
	            ] },
	            $currentDate: { "lastModified": true }
	        }, function(err, results) {
	        console.log(results);
	        callback();
	    });
	    };
    
	    var removeFamilies = function(db, callback) {
	    db.collection('families').deleteMany(
	        { "lastName": "Andersen" },
	        function(err, results) {
	            console.log(results);
	            callback();
	        }
	    );
	    };
    
	    MongoClient.connect(url, function(err, db) {
	    assert.equal(null, err);
	    insertDocument(db, function() {
	        findFamilies(db, function() {
	        updateFamilies(db, function() {
	            removeFamilies(db, function() {
	                db.close();
	            });
	        });
	        });
	    });
	    });


2. Modify the following variables in the *app.js* file per your account settings (Learn how to find your [connection string](/documentation/articles/documentdb-connect-mongodb-account/)):
   
	nodejs

		var url = 'mongodb://<endpoint>:<password>@<endpoint>.documents.azure.com:10250/?ssl=true';

     
3. Open your favorite terminal, run **npm install mongodb --save**, then run your app with **node app.js**

## Next steps
- Learn how to [use MongoChef](/documentation/articles/documentdb-mongodb-mongochef/) with your DocumentDB: API for MongoDB account.
