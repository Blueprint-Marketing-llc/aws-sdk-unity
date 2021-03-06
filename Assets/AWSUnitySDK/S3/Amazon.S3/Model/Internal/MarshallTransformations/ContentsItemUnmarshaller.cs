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
using System.Collections.Generic;

using Amazon.S3.Model;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
     /// <summary>
     ///   ContentsItem Unmarshaller
     /// </summary>
    internal class ContentsItemUnmarshaller : IUnmarshaller<S3Object, XmlUnmarshallerContext>, IUnmarshaller<S3Object, JsonUnmarshallerContext> 
    {
        public S3Object Unmarshall(XmlUnmarshallerContext context) 
        {
            S3Object contentsItem = new S3Object();
            int originalDepth = context.CurrentDepth;
            int targetDepth = originalDepth + 1;
            
            if (context.IsStartOfDocument) 
               targetDepth += 2;
            
            while (context.Read())
            {
                if (context.IsStartElement || context.IsAttribute)
                {
                    if (context.TestExpression("ETag", targetDepth))
                    {
                        contentsItem.ETag = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("Key", targetDepth))
                    {
                        contentsItem.Key = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("LastModified", targetDepth))
                    {
                        contentsItem.LastModified = DateTimeUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("Owner", targetDepth))
                    {
                        contentsItem.Owner = OwnerUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("Size", targetDepth))
                    {
                        contentsItem.Size = LongUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                    if (context.TestExpression("StorageClass", targetDepth))
                    {
                        contentsItem.StorageClass = StringUnmarshaller.GetInstance().Unmarshall(context);
                            
                        continue;
                    }
                }
                else if (context.IsEndElement && context.CurrentDepth < originalDepth)
                {
                    return contentsItem;
                }
            }
                        


            return contentsItem;
        }

        public S3Object Unmarshall(JsonUnmarshallerContext context) 
        {
            return null;
        }

        private static ContentsItemUnmarshaller instance;

        public static ContentsItemUnmarshaller GetInstance() 
        {
            if (instance == null) 
               instance = new ContentsItemUnmarshaller();

            return instance;
        }
    }
}
    
