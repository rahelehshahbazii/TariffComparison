using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;

namespace TariffComparison.Test
{
    [TestClass]
    public class ProductTests
    {
        //Access To APIs based on using HTTP Request 
        private HttpClient _client;

        public ProductTests()
        {

            //Startup is the Start up of the TariffComparison Project( including All of the Dependencies, contexts and etc).
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            //Createclient is used here in inorder to give an resuest 
            _client = server.CreateClient();

        }
      
        [TestMethod]
        /* 
          Any Method Test should contain Test Prefix 
          Here , the Get Method Of the Product is implemented 
        */
        public void ProductGetAllTest()
        {
            // Sending Request To API - /api/Products is URL for Get Request 
            var request = new HttpRequestMessage(new HttpMethod("Get"), "/api/Products");

            // The respone in which is returened   
            var response = _client.SendAsync(request).Result;

            /* 
             Use Assert for executing test.
             The First Parameter is the one thing we want to happen and the second Parameter is returned by API and
             we need both of them be equal 
            */
            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        
        //Giving one value for testing Get By Value 
        [DataRow(1)]    // There is a ProductId in the Product Table with the value=1
        public void ProductGetOneTest(int id)
        {

            // Sending Request To API - /api/Products/id is URL for Get Request with id=1 as a value 
            var request = new HttpRequestMessage(new HttpMethod("Get"), $"/api/Products/{id}");

            // The respone in which is returened   
            var response = _client.SendAsync(request).Result;

            /* 
             Use Assert for executing test.
             The First Parameter is the one thing we want to happen and the second Parameter is returned by API and
             we need both of them be equal 
            */
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

       
        [TestMethod]
        public void ProductPostTest()
        {
            // Sending Request To API - /api/Products is URL for Post Request 
            var request = new HttpRequestMessage(new HttpMethod("Post"), $"/api/Products");

            // The respone in which is returened   
            var response = _client.SendAsync(request).Result;

            /* 
             Use Assert for executing test.
             If There is not any Information as an enterance value, The First Parameter is chosen as UnsupportedMediaType 
             and the second Parameter is returned by API and we need test that both of them are equal 
            */
            Assert.AreEqual(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }


        [TestMethod]
        [DataRow(1)]   // There is a ProductId in the Product Table with the value=1
        public void ProductPutTest(int id)
        {
          
            // Sending Request To API - /api/Products/id is URL for Put Request with id=1 as a value for update 
            var request = new HttpRequestMessage(new HttpMethod("Put"), $"/api/Products/{id}");

            // The respone in which is returened   
            var response = _client.SendAsync(request).Result;

            /* 
            Use Assert for executing test.
            If There is not any Information as an enterance value, The First Parameter is chosen as UnsupportedMediaType 
            and the second Parameter is returned by API and we need test that both of them are equal 
           */
            Assert.AreEqual(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }


        [TestMethod]
        [DataRow(1)]  // There is a ProductId in the Product Table with the value=1
        public void ProductDeleteTest(int id)
        {
            // Sending Request To API - /api/Products/id is URL for Delete Request with id=1 as a value 
            var request = new HttpRequestMessage(new HttpMethod("Delete"), $"/api/Products/{id}");

            // The respone in which is returened   
            var response = _client.SendAsync(request).Result;

            /* 
              Use Assert for executing test.
              The First Parameter is the one thing we want to happen and the second Parameter is returned by API and
              we need both of them be equal  
           */
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
