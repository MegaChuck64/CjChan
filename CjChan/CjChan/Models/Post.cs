using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace CjChan.Models
{
    public class Post : TableEntity
    {

        public string Title { get; set; }
        public string ID { get; set; }
        public string Description { get; set; }

        public Post(string title, string description)
        {

            ID = Guid.NewGuid().ToString();
            Title = title;

            PartitionKey =  ID;
            RowKey =        Title;
        }
    }
}