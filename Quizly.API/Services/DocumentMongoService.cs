﻿using System;
using System.Collections.Generic;
using MongoDB.Driver;
using Quizly.Model;

namespace Quizly.API.Services
{
    public class DocumentMongoService : IDocumentService
    {
        private readonly IMongoCollection<Document> _documents;
        public DocumentMongoService(IQuizlyDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _documents = database.GetCollection<Document>(settings.DocumentsCollectionName);
        }

        public IEnumerable<Document> Get()
        {
            var documents = _documents.Find(document => true).ToList();
            return documents;
        }

        public Document GetDocumentById(string id)
        {
            return _documents.Find(x => x._id == id).FirstOrDefault();
        }

        public IEnumerable<Document> GetPinned()
        {
            return _documents.Find(document => document.pinned).ToList();
        }

        public IEnumerable<Document> GetRecent()
        {
            return _documents.Find(document => true).Limit(5).ToList();
        }

        public Document Delete(string id)
        {            
            return _documents.FindOneAndDelete(x => x._id == id);
        }

        public Document PinDocument(string id)
        {
            var newDocument = _documents.Find(document => document._id == id).FirstOrDefault();
            newDocument.pinned = !newDocument.pinned;
            _documents.FindOneAndReplace(x => x._id == id, newDocument);
            return newDocument;
        }
        public Document CreateDocument(Document document)
        {
            _documents.InsertOne(document);
            return document;
        }
    }
}
