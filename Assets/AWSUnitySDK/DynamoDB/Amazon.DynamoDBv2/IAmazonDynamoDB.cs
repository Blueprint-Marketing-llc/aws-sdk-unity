/*
 * Copyright 2014-2014 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *
 *
 * Licensed under the AWS Mobile SDK for Unity Developer Preview License Agreement (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located in the "license" file accompanying this file.
 * See the License for the specific language governing permissions and limitations under the License.
 *
 */


using System;

using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;

namespace Amazon.DynamoDBv2
{
    /// <summary>
    /// Implementation for accessing DynamoDB
    ///
    /// Amazon DynamoDB    <b>Overview</b>    
    /// <para>
    /// This is the Amazon DynamoDB API Reference. This guide provides descriptions and samples
    /// of the low-level      DynamoDB API. For information about DynamoDB application development,
    /// go to the <a href="http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/">Amazon
    /// DynamoDB Developer Guide</a>.
    /// </para>
    ///     
    /// <para>
    /// Instead of making the requests to the low-level DynamoDB API directly from your application,
    /// we      recommend that you use the AWS Software Development Kits (SDKs). The easy-to-use
    /// libraries in      the AWS SDKs make it unnecessary to call the low-level DynamoDB
    /// API directly from your      application. The libraries take care of request authentication,
    /// serialization, and connection      management. For more information, go to <a href="http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/UsingAWSSDK.html">Using
    /// the AWS        SDKs with DynamoDB</a> in the <i>Amazon DynamoDB Developer Guide</i>.
    /// </para>
    ///     
    /// <para>
    /// If you decide to code against the low-level DynamoDB API directly, you will need to
    /// write the      necessary code to authenticate your requests. For more information
    /// on signing your requests,      go to <a href="http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/API.html">Using
    /// the DynamoDB API</a> in the      <i>Amazon DynamoDB Developer Guide</i>.
    /// </para>
    ///     
    /// <para>
    /// The following are short descriptions of each low-level API action, organized by function.
    /// </para>
    ///     
    /// <para>
    ///       <b>Managing Tables</b>    
    /// </para>
    ///     
    /// <para>
    ///       <ul>        <li>          
    /// <para>
    /// <i>CreateTable</i> - Creates a table with user-specified provisioned throughput  
    ///          settings. You must designate one attribute as the hash primary key for the
    /// table; you            can optionally designate a second attribute as the range primary
    /// key. DynamoDB creates            indexes on these key attributes for fast data access.
    /// Optionally, you can create one or            more secondary indexes, which provide
    /// fast data access using non-key attributes.
    /// </para>
    ///         </li>        <li>          
    /// <para>
    /// <i>DescribeTable</i> - Returns metadata for a table, such as table size, status, and
    ///            index information.
    /// </para>
    ///         </li>        <li>          
    /// <para>
    /// <i>UpdateTable</i> - Modifies the provisioned throughput settings for a table.   
    ///         Optionally, you can modify the provisioned throughput settings for global
    /// secondary indexes on the            table.
    /// </para>
    ///         </li>        <li>          
    /// <para>
    /// <i>ListTables</i> - Returns a list of all tables associated with the current AWS 
    ///           account and endpoint.
    /// </para>
    ///         </li>        <li>          
    /// <para>
    /// <i>DeleteTable</i> - Deletes a table and all of its indexes.
    /// </para>
    ///         </li>      </ul>    
    /// </para>
    ///     
    /// <para>
    /// For conceptual information about managing tables, go to <a href="http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/WorkingWithTables.html">Working
    /// with Tables</a> in the        <i>Amazon DynamoDB Developer Guide</i>.
    /// </para>
    ///     
    /// <para>
    ///       <b>Reading Data</b>    
    /// </para>
    ///     
    /// <para>
    ///       <ul>        <li>          
    /// <para>
    /// <i>GetItem</i> - Returns a set of attributes for the item that has a given primary
    /// key.            By default, <i>GetItem</i> performs an eventually consistent read;
    /// however, applications            can specify a strongly consistent read instead.
    /// </para>
    ///         </li>        <li>          
    /// <para>
    /// <i>BatchGetItem</i> - Performs multiple <i>GetItem</i> requests for data items using
    ///            their primary keys, from one table or multiple tables. The response from
    ///              <i>BatchGetItem</i> has a size limit of 1 MB and returns a maximum of
    ///            100 items. Both eventually consistent and strongly            consistent
    /// reads can be used.
    /// </para>
    ///         </li>        <li>          
    /// <para>
    /// <i>Query</i> - Returns one or more items from a table or a secondary index. You must
    /// provide a            specific hash key value. You can narrow the scope of the query
    /// using comparison            operators against a range key value, or on the index key.
    /// <i>Query</i> supports either            eventual or strong consistency. A single response
    /// has a size limit of            1 MB.
    /// </para>
    ///         </li>        <li>          
    /// <para>
    /// <i>Scan</i> - Reads every item in a table; the result set is eventually consistent.
    /// You            can limit the number of items returned by filtering the data attributes,
    /// using            conditional expressions. <i>Scan</i> can be used to enable ad-hoc
    /// querying of a table            against non-key attributes; however, since this is
    /// a full table scan without using an            index, <i>Scan</i> should not be used
    /// for any application query use case that requires            predictable performance.
    /// </para>
    ///         </li>      </ul>    
    /// </para>
    ///     
    /// <para>
    /// For conceptual information about reading data, go to <a href="http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/WorkingWithItems.html">Working
    /// with Items</a> and <a href="http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/QueryAndScan.html">Query
    /// and Scan Operations</a> in the        <i>Amazon DynamoDB Developer Guide</i>.
    /// </para>
    ///     
    /// <para>
    ///       <b>Modifying Data</b>    
    /// </para>
    ///     
    /// <para>
    ///       <ul>        <li>          
    /// <para>
    /// <i>PutItem</i> - Creates a new item, or replaces an existing item with a new item
    ///            (including all the attributes). By default, if an item in the table already
    /// exists with            the same primary key, the new item completely replaces the
    /// existing item. You can use            conditional operators to replace an item only
    /// if its attribute values match certain            conditions, or to insert a new item
    /// only if that item doesn't already exist.
    /// </para>
    ///         </li>        <li>          
    /// <para>
    /// <i>UpdateItem</i> - Modifies the attributes of an existing item. You can also use
    ///            conditional operators to perform an update only if the item's attribute
    /// values match            certain conditions.
    /// </para>
    ///         </li>        <li>          
    /// <para>
    /// <i>DeleteItem</i> - Deletes an item in a table by primary key. You can use conditional
    ///            operators to perform a delete an item only if the item's attribute values
    /// match certain            conditions.
    /// </para>
    ///         </li>        <li>          
    /// <para>
    /// <i>BatchWriteItem</i> - Performs multiple <i>PutItem</i> and <i>DeleteItem</i> requests
    ///            across multiple tables in a single request. A failure of any request(s)
    /// in the batch            will not cause the entire <i>BatchWriteItem</i> operation
    /// to fail. Supports batches of            up to 25 items to put or delete, with a maximum
    /// total            request size of 1 MB. 
    /// </para>
    ///         </li>      </ul>    
    /// </para>
    ///     
    /// <para>
    /// For conceptual information about modifying data, go to <a href="http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/WorkingWithItems.html">Working
    /// with Items</a> and <a href="http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/QueryAndScan.html">Query
    /// and Scan Operations</a> in the        <i>Amazon DynamoDB Developer Guide</i>.
    /// </para>
    /// </summary>
    public partial interface IAmazonDynamoDB : IDisposable
    {

        
        #region  BatchGetItem


        /// <summary>
        /// Initiates the asynchronous execution of the BatchGetItem operation.
        /// <seealso cref="Amazon.DynamoDBv2.IAmazonDynamoDB"/>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the BatchGetItem operation.</param>
        /// <param name="callback">An AsyncCallback delegate that is invoked when the operation completes</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        void BatchGetItemAsync(BatchGetItemRequest request, AmazonServiceCallback callback, object state);

        #endregion
        
        #region  BatchWriteItem


        /// <summary>
        /// Initiates the asynchronous execution of the BatchWriteItem operation.
        /// <seealso cref="Amazon.DynamoDBv2.IAmazonDynamoDB"/>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the BatchWriteItem operation.</param>
        /// <param name="callback">An AsyncCallback delegate that is invoked when the operation completes</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        void BatchWriteItemAsync(BatchWriteItemRequest request, AmazonServiceCallback callback, object state);

        #endregion
        
        #region  CreateTable


        /// <summary>
        /// Initiates the asynchronous execution of the CreateTable operation.
        /// <seealso cref="Amazon.DynamoDBv2.IAmazonDynamoDB"/>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the CreateTable operation.</param>
        /// <param name="callback">An AsyncCallback delegate that is invoked when the operation completes</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        void CreateTableAsync(CreateTableRequest request, AmazonServiceCallback callback, object state);

        #endregion
        
        #region  DeleteItem


        /// <summary>
        /// Initiates the asynchronous execution of the DeleteItem operation.
        /// <seealso cref="Amazon.DynamoDBv2.IAmazonDynamoDB"/>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the DeleteItem operation.</param>
        /// <param name="callback">An AsyncCallback delegate that is invoked when the operation completes</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        void DeleteItemAsync(DeleteItemRequest request, AmazonServiceCallback callback, object state);

        #endregion
        
        #region  DeleteTable


        /// <summary>
        /// Initiates the asynchronous execution of the DeleteTable operation.
        /// <seealso cref="Amazon.DynamoDBv2.IAmazonDynamoDB"/>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the DeleteTable operation.</param>
        /// <param name="callback">An AsyncCallback delegate that is invoked when the operation completes</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        void DeleteTableAsync(DeleteTableRequest request, AmazonServiceCallback callback, object state);

        #endregion
        
        #region  DescribeTable


        /// <summary>
        /// Initiates the asynchronous execution of the DescribeTable operation.
        /// <seealso cref="Amazon.DynamoDBv2.IAmazonDynamoDB"/>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the DescribeTable operation.</param>
        /// <param name="callback">An AsyncCallback delegate that is invoked when the operation completes</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        void DescribeTableAsync(DescribeTableRequest request, AmazonServiceCallback callback, object state);

        #endregion
        
        #region  GetItem


        /// <summary>
        /// Initiates the asynchronous execution of the GetItem operation.
        /// <seealso cref="Amazon.DynamoDBv2.IAmazonDynamoDB"/>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the GetItem operation.</param>
        /// <param name="callback">An AsyncCallback delegate that is invoked when the operation completes</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        void GetItemAsync(GetItemRequest request, AmazonServiceCallback callback, object state);

        #endregion
        
        #region  ListTables


        /// <summary>
        /// Initiates the asynchronous execution of the ListTables operation.
        /// <seealso cref="Amazon.DynamoDBv2.IAmazonDynamoDB"/>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the ListTables operation.</param>
        /// <param name="callback">An AsyncCallback delegate that is invoked when the operation completes</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        void ListTablesAsync(ListTablesRequest request, AmazonServiceCallback callback, object state);

        #endregion
        
        #region  PutItem


        /// <summary>
        /// Initiates the asynchronous execution of the PutItem operation.
        /// <seealso cref="Amazon.DynamoDBv2.IAmazonDynamoDB"/>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the PutItem operation.</param>
        /// <param name="callback">An AsyncCallback delegate that is invoked when the operation completes</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        void PutItemAsync(PutItemRequest request, AmazonServiceCallback callback, object state);

        #endregion
        
        #region  Query


        /// <summary>
        /// Initiates the asynchronous execution of the Query operation.
        /// <seealso cref="Amazon.DynamoDBv2.IAmazonDynamoDB"/>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the Query operation.</param>
        /// <param name="callback">An AsyncCallback delegate that is invoked when the operation completes</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        void QueryAsync(QueryRequest request, AmazonServiceCallback callback, object state);

        #endregion
        
        #region  Scan


        /// <summary>
        /// Initiates the asynchronous execution of the Scan operation.
        /// <seealso cref="Amazon.DynamoDBv2.IAmazonDynamoDB"/>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the Scan operation.</param>
        /// <param name="callback">An AsyncCallback delegate that is invoked when the operation completes</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        void ScanAsync(ScanRequest request, AmazonServiceCallback callback, object state);

        #endregion
        
        #region  UpdateItem


        /// <summary>
        /// Initiates the asynchronous execution of the UpdateItem operation.
        /// <seealso cref="Amazon.DynamoDBv2.IAmazonDynamoDB"/>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the UpdateItem operation.</param>
        /// <param name="callback">An AsyncCallback delegate that is invoked when the operation completes</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        void UpdateItemAsync(UpdateItemRequest request, AmazonServiceCallback callback, object state);

        #endregion
        
        #region  UpdateTable


        /// <summary>
        /// Initiates the asynchronous execution of the UpdateTable operation.
        /// <seealso cref="Amazon.DynamoDBv2.IAmazonDynamoDB"/>
        /// </summary>
        /// <param name="request">Container for the necessary parameters to execute the UpdateTable operation.</param>
        /// <param name="callback">An AsyncCallback delegate that is invoked when the operation completes</param>
        /// <param name="state">A user-defined state object that is passed to the callback procedure. Retrieve this object from within the callback
        ///          procedure using the AsyncState property.</param>
        /// <returns>void</returns>
        void UpdateTableAsync(UpdateTableRequest request, AmazonServiceCallback callback, object state);

        #endregion
        
    }
}