// ***********************************************************************
// Assembly         : MerrillBridgeService
// Author           : Deepakkumar G
// Created          : 03-31-2015
//
// Last Modified By : Deepakkumar G
// Last Modified On : 03-31-2015
// ***********************************************************************
// <copyright file="UnityConfig.cs" company="Aditi Technologies">
//     Copyright (c) Aditi Technologies. All rights reserved.
// </copyright>
// <summary>Defines the UnityConfig type.</summary>
// ***********************************************************************

namespace MerrillBridgeService
{
    using System.Web.Http;

    using Merrill.Api.Service;
    using Merrill.Commands;
    using Merrill.Infrastructure.Messaging;

    using Microsoft.Practices.Unity;

    using Unity.WebApi;

    /// <summary>
    /// The unity config.
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// The register components.
        /// </summary>
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            string serviceBus = "Endpoint=sb://merrillbus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=PW2jZn1d/XdwSWOEVVK8nAqD1ML49PGyqApBSXC8VUk=";
            container.RegisterType<ICommandBus, CommandBus>(new HierarchicalLifetimeManager());
            var serializer = new JsonTextSerializer();
            container.RegisterInstance<ITextSerializer>(serializer, new ContainerControlledLifetimeManager());
            container.RegisterType<ICommandHandlerFactory, CommandHandlerFactory>("handler");
            var msgSender1 = container.Resolve<ICommandHandlerFactory>("handler");
            var metadata = new StandardMetadataProvider();
            MessageReciever msgReciever = new MessageReciever(serviceBus, serializer, msgSender1);
            container.RegisterInstance<IMetadataProvider>(metadata, new ContainerControlledLifetimeManager());
            container.RegisterInstance<IMessageReciever>(msgReciever, new ContainerControlledLifetimeManager());
            MessageSender msgSender = new MessageSender(serviceBus);
            ICommandBus commandBus = new CommandBus(msgSender, metadata, serializer);
            container.RegisterInstance(commandBus);
            container.Resolve<ICommandBus>();
            container.RegisterType<ICommandHandler<CreateNewProjectCommand>, CreateNewProjectHandler>("handlerdeep",new HierarchicalLifetimeManager());

            var resolvedInstance = container.Resolve<ICommandHandler<CreateNewProjectCommand>>("handlerdeep");
            container.RegisterType<IProjectService, ProjectService>(new HierarchicalLifetimeManager());
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);




        }
    }
}