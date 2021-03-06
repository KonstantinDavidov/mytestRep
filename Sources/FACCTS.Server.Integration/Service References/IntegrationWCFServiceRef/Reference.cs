﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18046
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FACCTS.Server.Integration.IntegrationWCFServiceRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="IntegrationWCFServiceRef.IIntegrationWCFService")]
    public interface IIntegrationWCFService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntegrationWCFService/InsertManualIntegrationTask", ReplyAction="http://tempuri.org/IIntegrationWCFService/InsertManualIntegrationTaskResponse")]
        void InsertManualIntegrationTask(FACCTS.Server.Model.DataModel.ManualIntegrationTask task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntegrationWCFService/InsertManualIntegrationTask", ReplyAction="http://tempuri.org/IIntegrationWCFService/InsertManualIntegrationTaskResponse")]
        System.Threading.Tasks.Task InsertManualIntegrationTaskAsync(FACCTS.Server.Model.DataModel.ManualIntegrationTask task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntegrationWCFService/UpdateManualIntegrationTask", ReplyAction="http://tempuri.org/IIntegrationWCFService/UpdateManualIntegrationTaskResponse")]
        void UpdateManualIntegrationTask(FACCTS.Server.Model.DataModel.ManualIntegrationTask task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntegrationWCFService/UpdateManualIntegrationTask", ReplyAction="http://tempuri.org/IIntegrationWCFService/UpdateManualIntegrationTaskResponse")]
        System.Threading.Tasks.Task UpdateManualIntegrationTaskAsync(FACCTS.Server.Model.DataModel.ManualIntegrationTask task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntegrationWCFService/DeleteManualIntegrationTask", ReplyAction="http://tempuri.org/IIntegrationWCFService/DeleteManualIntegrationTaskResponse")]
        void DeleteManualIntegrationTask(FACCTS.Server.Model.DataModel.ManualIntegrationTask task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntegrationWCFService/DeleteManualIntegrationTask", ReplyAction="http://tempuri.org/IIntegrationWCFService/DeleteManualIntegrationTaskResponse")]
        System.Threading.Tasks.Task DeleteManualIntegrationTaskAsync(FACCTS.Server.Model.DataModel.ManualIntegrationTask task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntegrationWCFService/DeleteManualIntegrationTaskById", ReplyAction="http://tempuri.org/IIntegrationWCFService/DeleteManualIntegrationTaskByIdResponse" +
            "")]
        void DeleteManualIntegrationTaskById(int taskId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntegrationWCFService/DeleteManualIntegrationTaskById", ReplyAction="http://tempuri.org/IIntegrationWCFService/DeleteManualIntegrationTaskByIdResponse" +
            "")]
        System.Threading.Tasks.Task DeleteManualIntegrationTaskByIdAsync(int taskId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntegrationWCFService/InsertScheduledIntegrationTask", ReplyAction="http://tempuri.org/IIntegrationWCFService/InsertScheduledIntegrationTaskResponse")]
        void InsertScheduledIntegrationTask(FACCTS.Server.Model.DataModel.ScheduledIntegrationTask task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntegrationWCFService/InsertScheduledIntegrationTask", ReplyAction="http://tempuri.org/IIntegrationWCFService/InsertScheduledIntegrationTaskResponse")]
        System.Threading.Tasks.Task InsertScheduledIntegrationTaskAsync(FACCTS.Server.Model.DataModel.ScheduledIntegrationTask task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntegrationWCFService/UpdateScheduledIntegrationTask", ReplyAction="http://tempuri.org/IIntegrationWCFService/UpdateScheduledIntegrationTaskResponse")]
        void UpdateScheduledIntegrationTask(FACCTS.Server.Model.DataModel.ScheduledIntegrationTask task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntegrationWCFService/UpdateScheduledIntegrationTask", ReplyAction="http://tempuri.org/IIntegrationWCFService/UpdateScheduledIntegrationTaskResponse")]
        System.Threading.Tasks.Task UpdateScheduledIntegrationTaskAsync(FACCTS.Server.Model.DataModel.ScheduledIntegrationTask task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntegrationWCFService/DeleteScheduledIntegrationTask", ReplyAction="http://tempuri.org/IIntegrationWCFService/DeleteScheduledIntegrationTaskResponse")]
        void DeleteScheduledIntegrationTask(FACCTS.Server.Model.DataModel.ScheduledIntegrationTask task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntegrationWCFService/DeleteScheduledIntegrationTask", ReplyAction="http://tempuri.org/IIntegrationWCFService/DeleteScheduledIntegrationTaskResponse")]
        System.Threading.Tasks.Task DeleteScheduledIntegrationTaskAsync(FACCTS.Server.Model.DataModel.ScheduledIntegrationTask task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntegrationWCFService/DeleteScheduledIntegrationTaskById", ReplyAction="http://tempuri.org/IIntegrationWCFService/DeleteScheduledIntegrationTaskByIdRespo" +
            "nse")]
        void DeleteScheduledIntegrationTaskById(int taskId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIntegrationWCFService/DeleteScheduledIntegrationTaskById", ReplyAction="http://tempuri.org/IIntegrationWCFService/DeleteScheduledIntegrationTaskByIdRespo" +
            "nse")]
        System.Threading.Tasks.Task DeleteScheduledIntegrationTaskByIdAsync(int taskId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IIntegrationWCFServiceChannel : FACCTS.Server.Integration.IntegrationWCFServiceRef.IIntegrationWCFService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IntegrationWCFServiceClient : System.ServiceModel.ClientBase<FACCTS.Server.Integration.IntegrationWCFServiceRef.IIntegrationWCFService>, FACCTS.Server.Integration.IntegrationWCFServiceRef.IIntegrationWCFService {
        
        public IntegrationWCFServiceClient() {
        }
        
        public IntegrationWCFServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IntegrationWCFServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IntegrationWCFServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IntegrationWCFServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void InsertManualIntegrationTask(FACCTS.Server.Model.DataModel.ManualIntegrationTask task) {
            base.Channel.InsertManualIntegrationTask(task);
        }
        
        public System.Threading.Tasks.Task InsertManualIntegrationTaskAsync(FACCTS.Server.Model.DataModel.ManualIntegrationTask task) {
            return base.Channel.InsertManualIntegrationTaskAsync(task);
        }
        
        public void UpdateManualIntegrationTask(FACCTS.Server.Model.DataModel.ManualIntegrationTask task) {
            base.Channel.UpdateManualIntegrationTask(task);
        }
        
        public System.Threading.Tasks.Task UpdateManualIntegrationTaskAsync(FACCTS.Server.Model.DataModel.ManualIntegrationTask task) {
            return base.Channel.UpdateManualIntegrationTaskAsync(task);
        }
        
        public void DeleteManualIntegrationTask(FACCTS.Server.Model.DataModel.ManualIntegrationTask task) {
            base.Channel.DeleteManualIntegrationTask(task);
        }
        
        public System.Threading.Tasks.Task DeleteManualIntegrationTaskAsync(FACCTS.Server.Model.DataModel.ManualIntegrationTask task) {
            return base.Channel.DeleteManualIntegrationTaskAsync(task);
        }
        
        public void DeleteManualIntegrationTaskById(int taskId) {
            base.Channel.DeleteManualIntegrationTaskById(taskId);
        }
        
        public System.Threading.Tasks.Task DeleteManualIntegrationTaskByIdAsync(int taskId) {
            return base.Channel.DeleteManualIntegrationTaskByIdAsync(taskId);
        }
        
        public void InsertScheduledIntegrationTask(FACCTS.Server.Model.DataModel.ScheduledIntegrationTask task) {
            base.Channel.InsertScheduledIntegrationTask(task);
        }
        
        public System.Threading.Tasks.Task InsertScheduledIntegrationTaskAsync(FACCTS.Server.Model.DataModel.ScheduledIntegrationTask task) {
            return base.Channel.InsertScheduledIntegrationTaskAsync(task);
        }
        
        public void UpdateScheduledIntegrationTask(FACCTS.Server.Model.DataModel.ScheduledIntegrationTask task) {
            base.Channel.UpdateScheduledIntegrationTask(task);
        }
        
        public System.Threading.Tasks.Task UpdateScheduledIntegrationTaskAsync(FACCTS.Server.Model.DataModel.ScheduledIntegrationTask task) {
            return base.Channel.UpdateScheduledIntegrationTaskAsync(task);
        }
        
        public void DeleteScheduledIntegrationTask(FACCTS.Server.Model.DataModel.ScheduledIntegrationTask task) {
            base.Channel.DeleteScheduledIntegrationTask(task);
        }
        
        public System.Threading.Tasks.Task DeleteScheduledIntegrationTaskAsync(FACCTS.Server.Model.DataModel.ScheduledIntegrationTask task) {
            return base.Channel.DeleteScheduledIntegrationTaskAsync(task);
        }
        
        public void DeleteScheduledIntegrationTaskById(int taskId) {
            base.Channel.DeleteScheduledIntegrationTaskById(taskId);
        }
        
        public System.Threading.Tasks.Task DeleteScheduledIntegrationTaskByIdAsync(int taskId) {
            return base.Channel.DeleteScheduledIntegrationTaskByIdAsync(taskId);
        }
    }
}
