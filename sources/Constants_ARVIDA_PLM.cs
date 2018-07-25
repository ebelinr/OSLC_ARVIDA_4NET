using OSLC4Net.Core.Model;

namespace OSLC_ARVIDA
{
    public static class Constants
    {
        public const string SHACL_DOMAIN = "";
        public const string SHACL_NAMESPACE = "http://www.w3.org/ns/shacl#";
        public const string SHACL_NAMESPACE_PREFIX = "sh";

        public const string LDP_DOMAIN = "";
        public const string LDP_NAMESPACE = "http://www.w3.org/ns/ldp#";
        public const string LDP_NAMESPACE_PREFIX = "ldp";

        public static class vom
        {
            public const string VOM_DOMAIN = "http://vocab.arvida.de/2015/06/vom/";
            public const string VOM_NAMESPACE = "http://vocab.arvida.de/2015/06/vom/vocab#";
            public const string VOM_NAMESPACE_PREFIX = "vom";

            public const string TYPE_NUMERICAL_VALUE = "NumericalValue";
        }

        public static class Spartial
        {
            public const string SPARTIAL_DOMAIN = "http://vocab.arvida.de/2015/06/spatial/";
            public const string SPARTIAL_NAMESPACE = "http://vocab.arvida.de/2015/06/spatial/vocab#";
            public const string SPARTIAL_NAMESPACE_PREFIX = "spatial";

            public const string TYPE_SPARTIAL_3D_TRANSLATION = SPARTIAL_NAMESPACE + "Translation3D";
            public const string TYPE_SPARTIAL_3D_ROTATION = SPARTIAL_NAMESPACE + "Rotation3D";
        }

        public static class Scene
        {
            public const string SCENE_DOMAIN = "http://vocab.arvida.de/2015/06/scene/vocab#";
            public const string SCENE_NAMESPACE = "http://vocab.arvida.de/2015/06/scene/vocab#";
            public const string SCENE_NAMESPACE_PREFIX = "scene";
            
            public const string TYPE_SCENE = SCENE_NAMESPACE + "Scene";
            public const string TYPE_SCENE_VARIANT_SET = SCENE_NAMESPACE + "VariantSet";
            public const string TYPE_SCENE_VARIANT = SCENE_NAMESPACE + "Variant";
            public const string TYPE_SCENE_ROOT = SCENE_NAMESPACE + "SceneRoot";
            public const string TYPE_SCENE_TRIGGERABLE_ELEMENT = SCENE_NAMESPACE + "TriggerableElement";
            public const string TYPE_SCENE_TRIGGERABLE_ELEMENT_ACTION = SCENE_NAMESPACE + "TriggerableElementAction";
            public const string TYPE_SCENE_TRIGGERABLE_ELEMENT_CONTAINER = SCENE_NAMESPACE + "TriggerableElementContainer";
        }

        public static class SceneGraph
        {
            public const string SCENEGRAPH_DOMAIN = "http://vocab.arvida.de/2015/06/scenegraph/vocab#";
            public const string SCENEGRAPH_NAMESPACE = "http://vocab.arvida.de/2015/06/scenegraph/vocab#";
            public const string SCENEGRAPH_NAMESPACE_PREFIX = "sg";

            public const string TYPE_SCENEGRAPH_SCENE_NODE = SCENEGRAPH_NAMESPACE + "SceneNode";
            public const string TYPE_SCENEGRAPH_TRANSFORMATION_GROUP_NODE = SCENEGRAPH_NAMESPACE + "TransformationGroupNode";
            public const string TYPE_SCENEGRAPH_TRANSFORMATION_GROUP_NODE_CHILD = SCENEGRAPH_NAMESPACE + "TransformationGroupChild";
            public const string TYPE_SCENEGRAPH_TRANSFORMATION_GROUP_NODE_PARENT = SCENEGRAPH_NAMESPACE + "TransformationGroupParent";
            public const string TYPE_SCENEGRAPH_PART_OF = SCENEGRAPH_NAMESPACE + "PartOf";
            public const string TYPE_SCENEGRAPH_PART_OF_NODE = SCENEGRAPH_NAMESPACE + "PartOfNode";
            public const string TYPE_SCENEGRAPH_RENDER_COMPONENT = SCENEGRAPH_NAMESPACE + "RenderComponent";
        }        

        public static class Maths
        {
            public const string MATHS_DOMAIN = "http://vocab.arvida.de/2015/06/maths/";
            public const string MATHS_NAMESPACE = "http://vocab.arvida.de/2015/06/maths/vocab#";
            public const string MATHS_NAMESPACE_PREFIX = "maths"; 
            
            public const string TYPE_3D_VECTOR = MATHS_NAMESPACE + "Vector3D";
            public const string TYPE_X = MATHS_NAMESPACE + "X";
            public const string TYPE_Y = MATHS_NAMESPACE + "Y";
            public const string TYPE_Z = MATHS_NAMESPACE + "Z";

            public const string TYPE_3D_MATRIX = MATHS_NAMESPACE + "Matrix3D";
            public const string TYPE_A_11 = MATHS_NAMESPACE + "A11";
            public const string TYPE_A_12 = MATHS_NAMESPACE + "A12";
            public const string TYPE_A_13 = MATHS_NAMESPACE + "A13";
            public const string TYPE_A_21 = MATHS_NAMESPACE + "A21";
            public const string TYPE_A_22 = MATHS_NAMESPACE + "A22";
            public const string TYPE_A_23 = MATHS_NAMESPACE + "A23";
            public const string TYPE_A_31 = MATHS_NAMESPACE + "A31";
            public const string TYPE_A_32 = MATHS_NAMESPACE + "A32";
            public const string TYPE_A_33 = MATHS_NAMESPACE + "A33";

            public const string TYPE_CARTESIAN_COORDINATE_SYSTEM_3D = MATHS_NAMESPACE + "CartesianCoordinateSystem3D";
        }

        public static class plm
        {
            // related to:
            // https://www.w3.org/2005/Incubator/w3pm/XGR-w3pm-20091008/
            // ISO 10303-214:2010(E)

            public const string PLM_DOMAIN = "http://localhost:9010/syslm/";
            public const string PLM_NAMESPACE = "http://localhost:9010/syslm/vocab#";
            public const string PLM_NAMESPACE_PREFIX = "plm";

            public const string TYPE_SPECIFICATION = PLM_NAMESPACE + "Specification";
        }

        public static class rdfsExtension
        {
            public const string TYPE_SUB_PROPERTY_OF = OslcConstants.RDFS_NAMESPACE + "subPropertyOf";
        }
    }
}
