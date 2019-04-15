﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Iyzipay
{
    public class IyzipayResourceV2
    {
        private static readonly string AUTHORIZATION = "Authorization";
        private static readonly string CONVERSATION_ID_HEADER_NAME = "x-conversation-id";
        private static readonly string CLIENT_VERSION_HEADER_NAME = "x-iyzi-client-version";
        private static readonly string IYZIWS_V2_HEADER_NAME = "IYZWSv2 ";

        public string Status { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ConversationId { get; set; }
        public long SystemTime { get; set; }

        public IyzipayResourceV2()
        {
        }

        public void AppendWithHttpResponseHeaders(HttpResponseMessage httpResponseMessage)
        {
            HttpHeaders responseHeaders = httpResponseMessage.Headers;
            this.StatusCode = Convert.ToInt32(httpResponseMessage.StatusCode);

            IEnumerable<string> values;
            if (responseHeaders.TryGetValues(CONVERSATION_ID_HEADER_NAME, out values))
            {
                string conversationId = values.First();
                this.ConversationId = !string.IsNullOrWhiteSpace(conversationId) ? conversationId : null;
            }
        }

        protected static WebHeaderCollection GetHttpHeadersWithRequestBody(BaseRequestV2 request, string url, Options options)
        {
            WebHeaderCollection headers = GetCommonHttpHeaders(request, url, options);
            headers.Add(AUTHORIZATION, PrepareAuthorizationStringWithRequestBody(request, url, options));
            return headers;
        }

        protected static WebHeaderCollection GetHttpHeadersWithUrlParams(BaseRequestV2 request, string url, Options options)
        {
            WebHeaderCollection headers = GetCommonHttpHeaders(request, url, options);
            headers.Add(AUTHORIZATION, PrepareAuthorizationStringWithUrlParam(request, url, options));
            return headers;
        }

        private static WebHeaderCollection GetCommonHttpHeaders(BaseRequestV2 request, string url, Options options)
        {
            WebHeaderCollection headers = new WebHeaderCollection();
            headers.Add("Accept", "application/json");
            headers.Add(CLIENT_VERSION_HEADER_NAME, IyzipayConstants.CLIENT_VERSION);
            headers.Add(CONVERSATION_ID_HEADER_NAME, request.ConversationId);
            return headers;
        }

        private static string PrepareAuthorizationStringWithRequestBody(BaseRequestV2 request, string url, Options options)
        {
            string randomKey = GenerateRandomKey();
            string uriPath = FindUriPath(url);
            string payload = request != null ? uriPath + JsonBuilder.SerializeToJsonString(request) : uriPath;
            string dataToEncrypt = randomKey + payload;

            string hash = HashGeneratorV2.GenerateHash(options.ApiKey, options.SecretKey, randomKey, dataToEncrypt);
            return IYZIWS_V2_HEADER_NAME + hash;
        }

        private static string PrepareAuthorizationStringWithUrlParam(BaseRequestV2 request, string url, Options options)
        {
            string randomKey = GenerateRandomKey();
            string uriPath = FindUriPath(url);
            string dataToEncrypt = randomKey + uriPath;

            string hash = HashGeneratorV2.GenerateHash(options.ApiKey, options.SecretKey, randomKey, dataToEncrypt);
            return IYZIWS_V2_HEADER_NAME + hash;
        }

        private static string GenerateRandomKey()
        {
            return DateTime.Now.ToString("ddMMyyyyhhmmssffff");
        }

        private static string FindUriPath(String url)
        {
            int startIndex = url.IndexOf("/v2");
            int endIndex = url.IndexOf("?");
            int length = endIndex == -1 ? url.Length - startIndex : endIndex - startIndex;
            return url.Substring(startIndex, length);
        }
    }
}
