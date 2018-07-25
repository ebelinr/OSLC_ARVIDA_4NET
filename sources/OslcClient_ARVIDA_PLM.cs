using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using OSLC4Net.Core.Model;
using OSLC4Net.Client;
using OSLC4Net.Core.DotNetRdfProvider;

namespace OSLC_ARVIDA
{
    public abstract class theVisualisation
    {
        private static readonly ISet<MediaTypeFormatter> FORMATTERS = new HashSet<MediaTypeFormatter>();

        static theVisualisation()
        {
            FORMATTERS.Add(new RdfXmlMediaTypeFormatter());
            FORMATTERS.Add(new OSLC4Net.Core.JsonProvider.JsonMediaTypeFormatter());
        }

        private static Uri CREATED_theVisualisation_URI;

        protected theVisualisation()
        {
        }

        private static String theCreationFactories(Service service, String type)
        {
            CreationFactory[] creationFactories = service.GetCreationFactories();
            foreach (CreationFactory creationFactory in creationFactories)
            {
                Uri[] resourceTypes = creationFactory.GetResourceTypes();

                foreach (Uri resourceType in resourceTypes)
                {
                    if (resourceType.ToString().Equals(type))
                    {
                        return creationFactory.GetCreation().ToString();
                    }
                }
            }
            throw new AssertFailedException("Unable to retrieve creation for type '" + type + "'");
        }


        public static String GetCreation(String mediaType, String type)
        {
            ServiceProvider[] serviceProviders = new ServiceProviderRegistryClient(FORMATTERS, mediaType).GetServiceProviders();
            foreach (ServiceProvider serviceProvider in serviceProviders)
            {
                Service[] services = serviceProvider.GetServices();
                foreach (Service service in services)
                {
                    if (OSLC_ARVIDA.Constants.Scene.SCENE_DOMAIN.Equals(service.GetDomain().ToString()))
                    {
                        return theCreationFactories(service, type);
                    }
                    if (OSLC_ARVIDA.Constants.SceneGraph.SCENEGRAPH_DOMAIN.Equals(service.GetDomain().ToString()))
                    {
                        return theCreationFactories(service, type);
                    }
                    if (OSLC_ARVIDA.Constants.Spartial.SPARTIAL_DOMAIN.Equals(service.GetDomain().ToString()))
                    {
                        return theCreationFactories(service, type);
                    }
                    if (OSLC_ARVIDA.Constants.Maths.MATHS_DOMAIN.Equals(service.GetDomain().ToString()))
                    {
                        return theCreationFactories(service, type);
                    }
                    if (OSLC_ARVIDA.Constants.vom.VOM_DOMAIN.Equals(service.GetDomain().ToString()))
                    {
                        return theCreationFactories(service, type);
                    }
                }
            }
            throw new AssertFailedException("Unable to retrieve creation for type '" + type + "'");
        }

        private static String theQueryCapabilities(Service service, String type)
        {
            QueryCapability[] queryCapabilities = service.GetQueryCapabilities();
            foreach (QueryCapability queryCapability in queryCapabilities)
            {
                Uri[] resourceTypes = queryCapability.GetResourceTypes();
                foreach (Uri resourceType in resourceTypes)
                {
                    if (resourceType.ToString().Equals(type))
                    {
                        return queryCapability.GetQueryBase().ToString();
                    }
                }
            }
            throw new AssertFailedException("Unable to retrieve queryBase for type '" + type + "'");
        }

        public static String GetQueryBase(String mediaType, String type)
        {
            ServiceProvider[] serviceProviders = new ServiceProviderRegistryClient(FORMATTERS, mediaType).GetServiceProviders();
            foreach (ServiceProvider serviceProvider in serviceProviders)
            {
                Service[] services = serviceProvider.GetServices();
                foreach (Service service in services)
                {
                    if (OSLC_ARVIDA.Constants.Scene.SCENE_DOMAIN.Equals(service.GetDomain().ToString()))
                    {
                        return theQueryCapabilities(service, type);
                    }
                    if (OSLC_ARVIDA.Constants.SceneGraph.SCENEGRAPH_DOMAIN.Equals(service.GetDomain().ToString()))
                    {
                        return theQueryCapabilities(service, type);
                    }
                    if (OSLC_ARVIDA.Constants.Spartial.SPARTIAL_DOMAIN.Equals(service.GetDomain().ToString()))
                    {
                        return theQueryCapabilities(service, type);
                    }
                    if (OSLC_ARVIDA.Constants.Maths.MATHS_DOMAIN.Equals(service.GetDomain().ToString()))
                    {
                        return theQueryCapabilities(service, type);
                    }
                    if (OSLC_ARVIDA.Constants.vom.VOM_DOMAIN.Equals(service.GetDomain().ToString()))
                    {
                        return theQueryCapabilities(service, type);
                    }
                }
            }
            throw new AssertFailedException("Unable to retrieve queryBase for type '" + type + "'");
        }

        private static ResourceShape GetResourceShapes(String mediaType, String type, Service service)
        {
            QueryCapability[] queryCapabilities = service.GetQueryCapabilities();
            foreach (QueryCapability queryCapability in queryCapabilities)
            {
                Uri[] resourceTypes = queryCapability.GetResourceTypes();
                foreach (Uri resourceType in resourceTypes)
                {
                    if (resourceType.ToString().Equals(type))
                    {
                        Uri resourceShape = queryCapability.GetResourceShape();
                        if (resourceShape != null)
                        {
                            OslcRestClient oslcRestClient = new OslcRestClient(FORMATTERS, resourceShape, mediaType);
                            return oslcRestClient.GetOslcResource<ResourceShape>();
                        }
                    }
                }
            }
            throw new AssertFailedException("Unable to retrieve resource shape for type '" + type + "'");
        }

        public static ResourceShape GetResourceShape(String mediaType, String type)
        {
            ServiceProviderRegistryClient myclient = new ServiceProviderRegistryClient(FORMATTERS, OslcMediaType.APPLICATION_RDF_XML, "http://localhost:9010/OSLC-ARVIDA-ServiceProviderCatalog/");
            ServiceProvider[] serviceProviders = myclient.GetServiceProviders();
            foreach (ServiceProvider serviceProvider in serviceProviders)
            {
                Service[] services = serviceProvider.GetServices();
                foreach (Service service in services)
                {
                    if (OSLC_ARVIDA.Constants.Scene.SCENE_DOMAIN.Equals(service.GetDomain().ToString()))
                    {
                        return GetResourceShapes(mediaType, type, service);
                    }
                }
            }
            throw new AssertFailedException("Unable to retrieve resource shape for type '" + type + "'");
        }

        public static void VerifyVariantSet(String mediaType, VariantSet thisV, bool recurse)
        {
            Assert.IsNotNull(thisV);

            Uri aboutURI = thisV.GetAbout();
            DateTime? createdDate = thisV.GetCreated();
            Variant[] variants = thisV.GetVariants();
            String identifierString = thisV.GetIdentifier();
            String titleString = thisV.GetTitle();
            Uri[] rdfTypesURIs = thisV.GetRdfTypes();
            Uri serviceProviderURI = thisV.GetServiceProvider();

            Assert.IsNotNull(aboutURI);
            Assert.IsNotNull(createdDate);
            Assert.IsNotNull(variants);
            Assert.IsNotNull(titleString);
            Assert.IsNotNull(rdfTypesURIs);
            Assert.IsNotNull(serviceProviderURI);

            Assert.IsTrue(aboutURI.ToString().EndsWith(identifierString));
            Assert.IsTrue(rdfTypesURIs.Contains(new Uri(OSLC_ARVIDA.Constants.Scene.TYPE_SCENE_VARIANT_SET)));

            if (recurse)
            {
                OslcRestClient aboutOSLCRestClient = new OslcRestClient(FORMATTERS,
                                                                        aboutURI,
                                                                        mediaType);

                VerifyVariantSet(mediaType,
                                    aboutOSLCRestClient.GetOslcResource<VariantSet>(),
                                    false);

                OslcRestClient serviceProviderOSLCRestClient = new OslcRestClient(FORMATTERS,
                                                                                  serviceProviderURI,
                                                                                  mediaType);

                ServiceProvider serviceProvider = serviceProviderOSLCRestClient.GetOslcResource<ServiceProvider>();

                Assert.IsNotNull(serviceProvider);
            }
        }

        public static void VerifyResourceShape(ResourceShape resourceShape,
                                        String type)
        {
            Assert.IsNotNull(resourceShape);

            Uri[] describes = resourceShape.GetDescribes();
            Assert.IsNotNull(describes);
            Assert.IsTrue(describes.Length > 0);

            if (type != null)
            {
                Assert.IsTrue(describes.Contains(new Uri(type)));
            }

            OSLC4Net.Core.Model.Property[] properties = resourceShape.GetProperties();

            Assert.IsNotNull(properties);
            Assert.IsTrue(properties.Length > 0);

            foreach (OSLC4Net.Core.Model.Property property in properties)
            {
                String name = property.GetName();
                Uri propertyDefinition = property.GetPropertyDefinition();

                Assert.IsNotNull(property.GetDescription());
                Assert.IsNotNull(name);
                Assert.IsNotNull(property.GetOccurs());
                Assert.IsNotNull(propertyDefinition);
                Assert.IsNotNull(property.GetTitle());
                Assert.IsNotNull(property.GetValueType());

                Assert.IsTrue(propertyDefinition.ToString().EndsWith(name),
                              "propertyDefinition [" + propertyDefinition.ToString() + "], name [" + name + "]");
            }
        }
    }
}
