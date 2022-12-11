﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryServiceReference
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Book", Namespace="http://tempuri.org/")]
    public partial class Book : object
    {
        
        private string IdField;
        
        private string TitleField;
        
        private string CategoryField;
        
        private string LangField;
        
        private int PagesField;
        
        private int AgeLimitField;
        
        private int PublicationDateField;
        
        private LibraryServiceReference.Author[] AuthorsField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Title
        {
            get
            {
                return this.TitleField;
            }
            set
            {
                this.TitleField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Category
        {
            get
            {
                return this.CategoryField;
            }
            set
            {
                this.CategoryField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string Lang
        {
            get
            {
                return this.LangField;
            }
            set
            {
                this.LangField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public int Pages
        {
            get
            {
                return this.PagesField;
            }
            set
            {
                this.PagesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public int AgeLimit
        {
            get
            {
                return this.AgeLimitField;
            }
            set
            {
                this.AgeLimitField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=6)]
        public int PublicationDate
        {
            get
            {
                return this.PublicationDateField;
            }
            set
            {
                this.PublicationDateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public LibraryServiceReference.Author[] Authors
        {
            get
            {
                return this.AuthorsField;
            }
            set
            {
                this.AuthorsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Author", Namespace="http://tempuri.org/")]
    public partial class Author : object
    {
        
        private string NameField;
        
        private string LangField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Lang
        {
            get
            {
                return this.LangField;
            }
            set
            {
                this.LangField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LibraryServiceReference.LibraryWebServiceSoap")]
    public interface LibraryWebServiceSoap
    {
        
        // CODEGEN: Generating message contract since element name GetAllBooksResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAllBooks", ReplyAction="*")]
        LibraryServiceReference.GetAllBooksResponse GetAllBooks(LibraryServiceReference.GetAllBooksRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAllBooks", ReplyAction="*")]
        System.Threading.Tasks.Task<LibraryServiceReference.GetAllBooksResponse> GetAllBooksAsync(LibraryServiceReference.GetAllBooksRequest request);
        
        // CODEGEN: Generating message contract since element name title from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetBooksByTitle", ReplyAction="*")]
        LibraryServiceReference.GetBooksByTitleResponse GetBooksByTitle(LibraryServiceReference.GetBooksByTitleRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetBooksByTitle", ReplyAction="*")]
        System.Threading.Tasks.Task<LibraryServiceReference.GetBooksByTitleResponse> GetBooksByTitleAsync(LibraryServiceReference.GetBooksByTitleRequest request);
        
        // CODEGEN: Generating message contract since element name author from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetBooksByAuthor", ReplyAction="*")]
        LibraryServiceReference.GetBooksByAuthorResponse GetBooksByAuthor(LibraryServiceReference.GetBooksByAuthorRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetBooksByAuthor", ReplyAction="*")]
        System.Threading.Tasks.Task<LibraryServiceReference.GetBooksByAuthorResponse> GetBooksByAuthorAsync(LibraryServiceReference.GetBooksByAuthorRequest request);
        
        // CODEGEN: Generating message contract since element name category from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetBooksByCategory", ReplyAction="*")]
        LibraryServiceReference.GetBooksByCategoryResponse GetBooksByCategory(LibraryServiceReference.GetBooksByCategoryRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetBooksByCategory", ReplyAction="*")]
        System.Threading.Tasks.Task<LibraryServiceReference.GetBooksByCategoryResponse> GetBooksByCategoryAsync(LibraryServiceReference.GetBooksByCategoryRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAllBooksRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetAllBooks", Namespace="http://tempuri.org/", Order=0)]
        public LibraryServiceReference.GetAllBooksRequestBody Body;
        
        public GetAllBooksRequest()
        {
        }
        
        public GetAllBooksRequest(LibraryServiceReference.GetAllBooksRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class GetAllBooksRequestBody
    {
        
        public GetAllBooksRequestBody()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAllBooksResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetAllBooksResponse", Namespace="http://tempuri.org/", Order=0)]
        public LibraryServiceReference.GetAllBooksResponseBody Body;
        
        public GetAllBooksResponse()
        {
        }
        
        public GetAllBooksResponse(LibraryServiceReference.GetAllBooksResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetAllBooksResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public LibraryServiceReference.Book[] GetAllBooksResult;
        
        public GetAllBooksResponseBody()
        {
        }
        
        public GetAllBooksResponseBody(LibraryServiceReference.Book[] GetAllBooksResult)
        {
            this.GetAllBooksResult = GetAllBooksResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetBooksByTitleRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetBooksByTitle", Namespace="http://tempuri.org/", Order=0)]
        public LibraryServiceReference.GetBooksByTitleRequestBody Body;
        
        public GetBooksByTitleRequest()
        {
        }
        
        public GetBooksByTitleRequest(LibraryServiceReference.GetBooksByTitleRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetBooksByTitleRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string title;
        
        public GetBooksByTitleRequestBody()
        {
        }
        
        public GetBooksByTitleRequestBody(string title)
        {
            this.title = title;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetBooksByTitleResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetBooksByTitleResponse", Namespace="http://tempuri.org/", Order=0)]
        public LibraryServiceReference.GetBooksByTitleResponseBody Body;
        
        public GetBooksByTitleResponse()
        {
        }
        
        public GetBooksByTitleResponse(LibraryServiceReference.GetBooksByTitleResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetBooksByTitleResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public LibraryServiceReference.Book[] GetBooksByTitleResult;
        
        public GetBooksByTitleResponseBody()
        {
        }
        
        public GetBooksByTitleResponseBody(LibraryServiceReference.Book[] GetBooksByTitleResult)
        {
            this.GetBooksByTitleResult = GetBooksByTitleResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetBooksByAuthorRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetBooksByAuthor", Namespace="http://tempuri.org/", Order=0)]
        public LibraryServiceReference.GetBooksByAuthorRequestBody Body;
        
        public GetBooksByAuthorRequest()
        {
        }
        
        public GetBooksByAuthorRequest(LibraryServiceReference.GetBooksByAuthorRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetBooksByAuthorRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string author;
        
        public GetBooksByAuthorRequestBody()
        {
        }
        
        public GetBooksByAuthorRequestBody(string author)
        {
            this.author = author;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetBooksByAuthorResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetBooksByAuthorResponse", Namespace="http://tempuri.org/", Order=0)]
        public LibraryServiceReference.GetBooksByAuthorResponseBody Body;
        
        public GetBooksByAuthorResponse()
        {
        }
        
        public GetBooksByAuthorResponse(LibraryServiceReference.GetBooksByAuthorResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetBooksByAuthorResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public LibraryServiceReference.Book[] GetBooksByAuthorResult;
        
        public GetBooksByAuthorResponseBody()
        {
        }
        
        public GetBooksByAuthorResponseBody(LibraryServiceReference.Book[] GetBooksByAuthorResult)
        {
            this.GetBooksByAuthorResult = GetBooksByAuthorResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetBooksByCategoryRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetBooksByCategory", Namespace="http://tempuri.org/", Order=0)]
        public LibraryServiceReference.GetBooksByCategoryRequestBody Body;
        
        public GetBooksByCategoryRequest()
        {
        }
        
        public GetBooksByCategoryRequest(LibraryServiceReference.GetBooksByCategoryRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetBooksByCategoryRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string category;
        
        public GetBooksByCategoryRequestBody()
        {
        }
        
        public GetBooksByCategoryRequestBody(string category)
        {
            this.category = category;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetBooksByCategoryResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetBooksByCategoryResponse", Namespace="http://tempuri.org/", Order=0)]
        public LibraryServiceReference.GetBooksByCategoryResponseBody Body;
        
        public GetBooksByCategoryResponse()
        {
        }
        
        public GetBooksByCategoryResponse(LibraryServiceReference.GetBooksByCategoryResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetBooksByCategoryResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public LibraryServiceReference.Book[] GetBooksByCategoryResult;
        
        public GetBooksByCategoryResponseBody()
        {
        }
        
        public GetBooksByCategoryResponseBody(LibraryServiceReference.Book[] GetBooksByCategoryResult)
        {
            this.GetBooksByCategoryResult = GetBooksByCategoryResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface LibraryWebServiceSoapChannel : LibraryServiceReference.LibraryWebServiceSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class LibraryWebServiceSoapClient : System.ServiceModel.ClientBase<LibraryServiceReference.LibraryWebServiceSoap>, LibraryServiceReference.LibraryWebServiceSoap
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public LibraryWebServiceSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(LibraryWebServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), LibraryWebServiceSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LibraryWebServiceSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(LibraryWebServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LibraryWebServiceSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(LibraryWebServiceSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LibraryWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        LibraryServiceReference.GetAllBooksResponse LibraryServiceReference.LibraryWebServiceSoap.GetAllBooks(LibraryServiceReference.GetAllBooksRequest request)
        {
            return base.Channel.GetAllBooks(request);
        }
        
        public LibraryServiceReference.Book[] GetAllBooks()
        {
            LibraryServiceReference.GetAllBooksRequest inValue = new LibraryServiceReference.GetAllBooksRequest();
            inValue.Body = new LibraryServiceReference.GetAllBooksRequestBody();
            LibraryServiceReference.GetAllBooksResponse retVal = ((LibraryServiceReference.LibraryWebServiceSoap)(this)).GetAllBooks(inValue);
            return retVal.Body.GetAllBooksResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<LibraryServiceReference.GetAllBooksResponse> LibraryServiceReference.LibraryWebServiceSoap.GetAllBooksAsync(LibraryServiceReference.GetAllBooksRequest request)
        {
            return base.Channel.GetAllBooksAsync(request);
        }
        
        public System.Threading.Tasks.Task<LibraryServiceReference.GetAllBooksResponse> GetAllBooksAsync()
        {
            LibraryServiceReference.GetAllBooksRequest inValue = new LibraryServiceReference.GetAllBooksRequest();
            inValue.Body = new LibraryServiceReference.GetAllBooksRequestBody();
            return ((LibraryServiceReference.LibraryWebServiceSoap)(this)).GetAllBooksAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        LibraryServiceReference.GetBooksByTitleResponse LibraryServiceReference.LibraryWebServiceSoap.GetBooksByTitle(LibraryServiceReference.GetBooksByTitleRequest request)
        {
            return base.Channel.GetBooksByTitle(request);
        }
        
        public LibraryServiceReference.Book[] GetBooksByTitle(string title)
        {
            LibraryServiceReference.GetBooksByTitleRequest inValue = new LibraryServiceReference.GetBooksByTitleRequest();
            inValue.Body = new LibraryServiceReference.GetBooksByTitleRequestBody();
            inValue.Body.title = title;
            LibraryServiceReference.GetBooksByTitleResponse retVal = ((LibraryServiceReference.LibraryWebServiceSoap)(this)).GetBooksByTitle(inValue);
            return retVal.Body.GetBooksByTitleResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<LibraryServiceReference.GetBooksByTitleResponse> LibraryServiceReference.LibraryWebServiceSoap.GetBooksByTitleAsync(LibraryServiceReference.GetBooksByTitleRequest request)
        {
            return base.Channel.GetBooksByTitleAsync(request);
        }
        
        public System.Threading.Tasks.Task<LibraryServiceReference.GetBooksByTitleResponse> GetBooksByTitleAsync(string title)
        {
            LibraryServiceReference.GetBooksByTitleRequest inValue = new LibraryServiceReference.GetBooksByTitleRequest();
            inValue.Body = new LibraryServiceReference.GetBooksByTitleRequestBody();
            inValue.Body.title = title;
            return ((LibraryServiceReference.LibraryWebServiceSoap)(this)).GetBooksByTitleAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        LibraryServiceReference.GetBooksByAuthorResponse LibraryServiceReference.LibraryWebServiceSoap.GetBooksByAuthor(LibraryServiceReference.GetBooksByAuthorRequest request)
        {
            return base.Channel.GetBooksByAuthor(request);
        }
        
        public LibraryServiceReference.Book[] GetBooksByAuthor(string author)
        {
            LibraryServiceReference.GetBooksByAuthorRequest inValue = new LibraryServiceReference.GetBooksByAuthorRequest();
            inValue.Body = new LibraryServiceReference.GetBooksByAuthorRequestBody();
            inValue.Body.author = author;
            LibraryServiceReference.GetBooksByAuthorResponse retVal = ((LibraryServiceReference.LibraryWebServiceSoap)(this)).GetBooksByAuthor(inValue);
            return retVal.Body.GetBooksByAuthorResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<LibraryServiceReference.GetBooksByAuthorResponse> LibraryServiceReference.LibraryWebServiceSoap.GetBooksByAuthorAsync(LibraryServiceReference.GetBooksByAuthorRequest request)
        {
            return base.Channel.GetBooksByAuthorAsync(request);
        }
        
        public System.Threading.Tasks.Task<LibraryServiceReference.GetBooksByAuthorResponse> GetBooksByAuthorAsync(string author)
        {
            LibraryServiceReference.GetBooksByAuthorRequest inValue = new LibraryServiceReference.GetBooksByAuthorRequest();
            inValue.Body = new LibraryServiceReference.GetBooksByAuthorRequestBody();
            inValue.Body.author = author;
            return ((LibraryServiceReference.LibraryWebServiceSoap)(this)).GetBooksByAuthorAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        LibraryServiceReference.GetBooksByCategoryResponse LibraryServiceReference.LibraryWebServiceSoap.GetBooksByCategory(LibraryServiceReference.GetBooksByCategoryRequest request)
        {
            return base.Channel.GetBooksByCategory(request);
        }
        
        public LibraryServiceReference.Book[] GetBooksByCategory(string category)
        {
            LibraryServiceReference.GetBooksByCategoryRequest inValue = new LibraryServiceReference.GetBooksByCategoryRequest();
            inValue.Body = new LibraryServiceReference.GetBooksByCategoryRequestBody();
            inValue.Body.category = category;
            LibraryServiceReference.GetBooksByCategoryResponse retVal = ((LibraryServiceReference.LibraryWebServiceSoap)(this)).GetBooksByCategory(inValue);
            return retVal.Body.GetBooksByCategoryResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<LibraryServiceReference.GetBooksByCategoryResponse> LibraryServiceReference.LibraryWebServiceSoap.GetBooksByCategoryAsync(LibraryServiceReference.GetBooksByCategoryRequest request)
        {
            return base.Channel.GetBooksByCategoryAsync(request);
        }
        
        public System.Threading.Tasks.Task<LibraryServiceReference.GetBooksByCategoryResponse> GetBooksByCategoryAsync(string category)
        {
            LibraryServiceReference.GetBooksByCategoryRequest inValue = new LibraryServiceReference.GetBooksByCategoryRequest();
            inValue.Body = new LibraryServiceReference.GetBooksByCategoryRequestBody();
            inValue.Body.category = category;
            return ((LibraryServiceReference.LibraryWebServiceSoap)(this)).GetBooksByCategoryAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.LibraryWebServiceSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.LibraryWebServiceSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpsTransportBindingElement httpsBindingElement = new System.ServiceModel.Channels.HttpsTransportBindingElement();
                httpsBindingElement.AllowCookies = true;
                httpsBindingElement.MaxBufferSize = int.MaxValue;
                httpsBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpsBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.LibraryWebServiceSoap))
            {
                return new System.ServiceModel.EndpointAddress("https://localhost:44361/LibraryWebService.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.LibraryWebServiceSoap12))
            {
                return new System.ServiceModel.EndpointAddress("https://localhost:44361/LibraryWebService.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            LibraryWebServiceSoap,
            
            LibraryWebServiceSoap12,
        }
    }
}
