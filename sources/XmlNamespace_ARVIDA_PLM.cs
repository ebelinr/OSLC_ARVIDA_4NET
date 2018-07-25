using OSLC4Net.Core.Attribute;
using OSLC4Net.Core.Model;

namespace OSLC_ARVIDA
{
     public static class XmlNamespace
    {
        private static readonly OslcNamespaceDefinition[] namespaces = new OslcNamespaceDefinition[]
        {
            new OslcNamespaceDefinition(prefix: OslcConstants.DCTERMS_NAMESPACE_PREFIX,             namespaceURI: OslcConstants.DCTERMS_NAMESPACE),
            new OslcNamespaceDefinition(prefix: OslcConstants.OSLC_CORE_NAMESPACE_PREFIX,           namespaceURI: OslcConstants.OSLC_CORE_NAMESPACE),
            new OslcNamespaceDefinition(prefix: OslcConstants.OSLC_DATA_NAMESPACE_PREFIX,           namespaceURI: OslcConstants.OSLC_DATA_NAMESPACE),
            new OslcNamespaceDefinition(prefix: OslcConstants.RDF_NAMESPACE_PREFIX,                 namespaceURI: OslcConstants.RDF_NAMESPACE),
            new OslcNamespaceDefinition(prefix: OslcConstants.RDFS_NAMESPACE_PREFIX,                namespaceURI: OslcConstants.RDFS_NAMESPACE),
            new OslcNamespaceDefinition(prefix: Constants.Maths.MATHS_NAMESPACE_PREFIX,             namespaceURI: Constants.Maths.MATHS_NAMESPACE),
            new OslcNamespaceDefinition(prefix: Constants.SceneGraph.SCENEGRAPH_NAMESPACE_PREFIX,   namespaceURI: Constants.SceneGraph.SCENEGRAPH_NAMESPACE),
            new OslcNamespaceDefinition(prefix: Constants.Scene.SCENE_NAMESPACE_PREFIX,             namespaceURI: Constants.Scene.SCENE_NAMESPACE),
            new OslcNamespaceDefinition(prefix: Constants.Spartial.SPARTIAL_NAMESPACE_PREFIX,       namespaceURI: Constants.Spartial.SPARTIAL_NAMESPACE),
            new OslcNamespaceDefinition(prefix: Constants.vom.VOM_NAMESPACE_PREFIX,                 namespaceURI: Constants.vom.VOM_NAMESPACE),
            new OslcNamespaceDefinition(prefix: Constants.SHACL_NAMESPACE_PREFIX,                   namespaceURI: Constants.SHACL_NAMESPACE),
            new OslcNamespaceDefinition(prefix: Constants.LDP_NAMESPACE_PREFIX,                     namespaceURI: Constants.LDP_NAMESPACE),
            new OslcNamespaceDefinition(prefix: Constants.plm.PLM_NAMESPACE_PREFIX,                 namespaceURI: Constants.plm.PLM_NAMESPACE),
            new OslcNamespaceDefinition(prefix: OslcConstants.XML_NAMESPACE_PREFIX,                 namespaceURI: OslcConstants.XML_NAMESPACE)
        };

        public static OslcNamespaceDefinition[] GetNamespaces() { return namespaces; }
    }
}
