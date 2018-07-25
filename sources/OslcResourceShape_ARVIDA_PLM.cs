using System;
using System.Collections.Generic;
using System.Linq;

using OSLC4Net.Core.Attribute;
using OSLC4Net.Core.Model;

namespace OSLC_ARVIDA
{
    [OslcNamespace(Constants.SceneGraph.SCENEGRAPH_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Scene Resource Shape", describes = new string[] { Constants.SceneGraph.TYPE_SCENEGRAPH_TRANSFORMATION_GROUP_NODE })]
    public class TransformationGroupNode : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes = new HashSet<Uri>();
        private readonly IList<string> allowedValues = new List<string>();
        private readonly ISet<string> subjects = new HashSet<string>();

        private Uri instanceShape;

        private ISet<Uri> TransformationGroupChilds = new HashSet<Uri>();
        private Uri TransformationGroupParent;

        private Translation3D translation3D;
        private Rotation3D rotation3D;

        private DateTime created;
        private string title;
        private Uri serviceProvider;

        public TransformationGroupNode()
            : base()
        {
            rdfTypes.Add(new Uri(Constants.SceneGraph.TYPE_SCENEGRAPH_TRANSFORMATION_GROUP_NODE));
        }

        public TransformationGroupNode(Uri about)
            : base(about)
        {
            rdfTypes.Add(new Uri(Constants.SceneGraph.TYPE_SCENEGRAPH_TRANSFORMATION_GROUP_NODE));
        }

        public void AddSubject(string subject)
        {
            this.subjects.Add(subject);
        }

        public void AddTransformationGroupChild(Uri transformationGroupChild)
        {
            this.TransformationGroupChilds.Add(transformationGroupChild);
        }

        [OslcDescription("Timestamp of resource creation.")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "created")]
        [OslcReadOnly]
        [OslcTitle("Created")]
        public DateTime GetCreated()
        {
            return created;
        }

        [OslcDescription("The resource type URIs.")]
        [OslcName("type")]
        [OslcPropertyDefinition(OslcConstants.RDF_NAMESPACE + "type")]
        [OslcTitle("Types")]
        public Uri[] GetRdfTypes()
        {
            return rdfTypes.ToArray();
        }

        [OslcDescription("The scope of a resource is a Uri for the resource's OSLC Service Provider.")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "serviceProvider")]
        [OslcRange(OslcConstants.TYPE_SERVICE_PROVIDER)]
        [OslcTitle("Service Provider")]
        public Uri GetServiceProvider()
        {
            return serviceProvider;
        }

        [OslcDescription("All TransformationGroup child relations.")]
        [OslcOccurs(Occurs.ZeroOrMany)]
        [OslcPropertyDefinition(Constants.SceneGraph.SCENEGRAPH_NAMESPACE + "transformationGroupChilds")]
        [OslcRange(Constants.SceneGraph.TYPE_SCENEGRAPH_TRANSFORMATION_GROUP_NODE_CHILD)]
        [OslcTitle("ARVIDA TransformationGroup Childs")]
        public Uri[] GetTransformationGroupChilds()
        {
            return TransformationGroupChilds.ToArray();
        }

        [OslcDescription("TransformationGroup parent relation.")]
        [OslcOccurs(Occurs.ZeroOrOne)]
        [OslcPropertyDefinition(Constants.SceneGraph.SCENEGRAPH_NAMESPACE + "transformationGroupParent")]
        [OslcRange(Constants.SceneGraph.TYPE_SCENEGRAPH_TRANSFORMATION_GROUP_NODE_PARENT)]
        [OslcTitle("ARVIDA TransformationGroup Parent")]
        public Uri GetTransformationGroupParent()
        {
            return TransformationGroupParent;
        }

        [OslcDescription("3D translation of TransformationGroup node.")]
        [OslcOccurs(Occurs.ZeroOrOne)]
        [OslcPropertyDefinition(Constants.Spartial.SPARTIAL_NAMESPACE + "translation3D")]
        [OslcRange(Constants.Spartial.TYPE_SPARTIAL_3D_TRANSLATION)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("ARVIDA 3D translation")]
        public Translation3D GetTranslation3D()
        {
            return translation3D;
        }

        [OslcDescription("3D rotation of TransformationGroup node.")]
        [OslcOccurs(Occurs.ZeroOrOne)]
        [OslcPropertyDefinition(Constants.Spartial.SPARTIAL_NAMESPACE + "rotation3D")]
        [OslcRange(Constants.Spartial.TYPE_SPARTIAL_3D_ROTATION)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("ARVIDA 3D rotation")]
        public Rotation3D GetRotation3D()
        {
            return rotation3D;
        }

        [OslcDescription("Title (reference: Dublin Core) or often a single line summary of the resource represented as rich text in XHTML content.")]
        [OslcOccurs(Occurs.ZeroOrOne)]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "title")]
        [OslcTitle("Title")]
        public string GetTitle()
        {
            return title;
        }

        [OslcDescription("Tag or keyword for a resource. Each occurrence of a dcterms:subject property denotes an additional tag for the resource.")]
        [OslcName("subject")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "subject")]
        [OslcReadOnly(false)]
        [OslcTitle("Subjects")]
        public string[] GetSubjects()
        {
            return subjects.ToArray();
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }

        public void SetRdfTypes(Uri[] rdfTypes)
        {
            this.rdfTypes.Clear();

            if (rdfTypes != null)
            {
                this.rdfTypes.AddAll(rdfTypes);
            }
        }

        public void SetServiceProvider(Uri serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void SetSubjects(string[] subjects)
        {
            this.subjects.Clear();

            if (subjects != null)
            {
                this.subjects.AddAll(subjects);
            }
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetTranslation3D(Translation3D translation3D)
        {
            this.translation3D = translation3D;
        }

        public void SetRotation3D(Rotation3D rotation3D)
        {
            this.rotation3D = rotation3D;
        }


        public void SetTransformationGroupChilds(Uri[] transformationGroupChilds)
        {
            this.TransformationGroupChilds.Clear();

            if (TransformationGroupChilds != null)
            {
                this.TransformationGroupChilds.AddAll(transformationGroupChilds);
            }
        }

        public void SetTransformationGroupParent(Uri transformationGroupParent)
        {
            this.TransformationGroupParent = transformationGroupParent;
        }

        public void SetCreated(DateTime created)
        {
            this.created = created;
        }
    }

    [OslcNamespace(Constants.plm.PLM_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Scene Resource Shape", describes = new string[] { Constants.plm.TYPE_SPECIFICATION })]
    public class Specification : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes = new HashSet<Uri>();
        private readonly IList<string> allowedValues = new List<string>();
        private readonly ISet<string> subjects = new HashSet<string>();

        private string identifier;

        private Uri instanceShape;

        private DateTime created;
        private string title;

        // Based on ISO 10303-214:2010(E) 4.2.488 Specification
        // The data associated with a Specification are the following: 
        // - category                           =>  not implemented or obsolete for RDF usage
        // - description                        =>  subjects
        // - id                                 =>  identifier 
        // - name (short description)           =>  title
        // - package;                           =>  not implemented or obsolete for RDF usage
        // - version_id.                        =>  "created"

        public Specification()
            : base()
        {
            rdfTypes.Add(new Uri(Constants.plm.TYPE_SPECIFICATION));
        }

        public Specification(Uri about)
            : base(about)
        {
            rdfTypes.Add(new Uri(Constants.plm.TYPE_SPECIFICATION));
        }

        public void AddSubject(string subject)
        {
            this.subjects.Add(subject);
        }

        [OslcDescription("A unique identifier for a resource. Assigned by the service provider when a resource is created. Not intended for end-user display.")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "identifier")]
        [OslcReadOnly]
        [OslcTitle("Identifier")]
        public string GetIdentifier()
        {
            return identifier;
        }

        [OslcDescription("Timestamp of resource creation.")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "created")]
        [OslcReadOnly]
        [OslcTitle("Created")]
        public DateTime GetCreated()
        {
            return created;
        }

        [OslcDescription("The resource type URIs.")]
        [OslcName("type")]
        [OslcPropertyDefinition(OslcConstants.RDF_NAMESPACE + "type")]
        [OslcTitle("Types")]
        public Uri[] GetRdfTypes()
        {
            return rdfTypes.ToArray();
        }

        [OslcDescription("Tag or keyword for a resource. Each occurrence of a dcterms:subject property denotes an additional tag for the resource.")]
        [OslcName("subject")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "subject")]
        [OslcTitle("Subjects")]
        public string[] GetSubjects()
        {
            return subjects.ToArray();
        }

        [OslcDescription("Title (reference: Dublin Core) or often a single line summary of the resource represented as rich text in XHTML content.")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "title")]
        [OslcTitle("Title")]
        public string GetTitle()
        {
            return title;
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetIdentifier(string identifier)
        {
            this.identifier = identifier;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }

        public void SetCreated(DateTime created)
        {
            this.created = created;
        }
        
        public void SetRdfTypes(Uri[] rdfTypes)
        {
            this.rdfTypes.Clear();

            if (rdfTypes != null)
            {
                this.rdfTypes.AddAll(rdfTypes);
            }
        }

        public void SetSubjects(string[] subjects)
        {
            this.subjects.Clear();

            if (subjects != null)
            {
                this.subjects.AddAll(subjects);
            }
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }
    }

    [OslcNamespace(Constants.Maths.MATHS_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Scene Resource Shape", describes = new string[] { Constants.Maths.TYPE_CARTESIAN_COORDINATE_SYSTEM_3D })]
    public class CartesianCoordinateSystem3D : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes = new HashSet<Uri>();
        private readonly IList<string> allowedValues = new List<string>();
        private readonly ISet<string> subjects = new HashSet<string>();

        private Uri instanceShape;

        // Cartesian Coordinate System c 
        // forward axis dp exactly 1
        // right axis dp exactly 1
        // up axis dp exactly 1
        // basis op value 3D Identity Matrix 
        // chirality op only 3x3 Matrix c 

        public CartesianCoordinateSystem3D()
            : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_CARTESIAN_COORDINATE_SYSTEM_3D));
        }

        public CartesianCoordinateSystem3D(Uri about)
            : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_CARTESIAN_COORDINATE_SYSTEM_3D));
        }
        
        [OslcDescription("The resource type URIs.")]
        [OslcName("type")]
        [OslcPropertyDefinition(OslcConstants.RDF_NAMESPACE + "type")]
        [OslcTitle("Types")]
        public Uri[] GetRdfTypes()
        {
            return rdfTypes.ToArray();
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }

        public void SetRdfTypes(Uri[] rdfTypes)
        {
            this.rdfTypes.Clear();

            if (rdfTypes != null)
            {
                this.rdfTypes.AddAll(rdfTypes);
            }
        }
    }

    [OslcNamespace(Constants.SceneGraph.SCENEGRAPH_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Scene Resource Shape", describes = new string[] { Constants.SceneGraph.TYPE_SCENEGRAPH_SCENE_NODE })]
    public class SceneNode : AbstractResource
    {
        #region property

        private readonly ISet<Uri> rdfTypes                     = new HashSet<Uri>();
        private readonly IList<string> allowedValues            =  new List<string>();
        private readonly ISet<string> subjects                  = new HashSet<string>();
        private readonly IList<PartOfNode> partOfNode           = new List<PartOfNode>();
        private readonly IList<Uri> partOfNodes           = new List<Uri>();

        private Uri instanceShape;

        private DateTime created;
        private string title;
        private Uri serviceProvider;
        // private CartesianCoordinateSystem3D cartesianCoordinateSystem3D;

        #endregion property

        #region initialization

        public SceneNode()
            : base()
        {
            rdfTypes.Add(new Uri(Constants.SceneGraph.TYPE_SCENEGRAPH_SCENE_NODE));
        }

        public SceneNode(Uri about)
            : base(about)
        {
            rdfTypes.Add(new Uri(Constants.SceneGraph.TYPE_SCENEGRAPH_SCENE_NODE));
        }

        public void AddSubject(string subject)
        {
            this.subjects.Add(subject);
        }

        public void AddPartOfNode(PartOfNode partOfNode)
        {
            this.partOfNode.Add(partOfNode);
        }

        #endregion initialization

        #region GetMethod

        [OslcDescription("Timestamp of resource creation.")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "created")]
        [OslcReadOnly]
        [OslcTitle("Created")]
        public DateTime GetCreated()
        {
            return created;
        }

        [OslcDescription("The resource type URIs.")]
        [OslcName("type")]
        [OslcOccurs(Occurs.ZeroOrMany)]
        [OslcPropertyDefinition(OslcConstants.RDF_NAMESPACE + "type")]
        [OslcTitle("Types")]
        public Uri[] GetRdfTypes()
        {
            return rdfTypes.ToArray();
        }

        [OslcDescription("ARVIDA derived object")]
        [OslcOccurs(Occurs.ZeroOrMany)]
        [OslcPropertyDefinition(Constants.SceneGraph.SCENEGRAPH_NAMESPACE + "partOfNode")]
        [OslcRange(Constants.SceneGraph.TYPE_SCENEGRAPH_PART_OF_NODE)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("ARVIDA partOfNode")]
        public PartOfNode[] GetPartOfNode()
        {
            return partOfNode.ToArray();
        }

        [OslcDescription("The scope of a resource is a Uri for the resource's OSLC Service Provider.")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "serviceProvider")]
        [OslcRange(OslcConstants.TYPE_SERVICE_PROVIDER)]
        [OslcTitle("Service Provider")]
        public Uri GetServiceProvider()
        {
            return serviceProvider;
        }

        [OslcDescription("Tag or keyword for a resource. Each occurrence of a dcterms:subject property denotes an additional tag for the resource.")]
        [OslcName("subject")]
        [OslcOccurs(Occurs.ZeroOrMany)]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "subject")]
        [OslcReadOnly(false)]
        [OslcTitle("Subjects")]
        public string[] GetSubjects()
        {
            return subjects.ToArray();
        }

        [OslcDescription("Title (reference: Dublin Core) or often a single line summary of the resource represented as rich text in XHTML content.")]
        [OslcName("title")]
        [OslcOccurs(Occurs.ZeroOrOne)]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "title")]
        [OslcTitle("Title")]
        public string GetTitle()
        {
            return title;
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }

        #endregion GetMethod

        #region SetMethod

        public void SetCreated(DateTime created)
        {
            this.created = created;
        }

        public void SetRdfTypes(Uri[] rdfTypes)
        {
            this.rdfTypes.Clear();

            if (rdfTypes != null)
            {
                this.rdfTypes.AddAll(rdfTypes);
            }
        }

        /*
        public void SetPartOfNode(Uri[] partOfNode)
        {
            this.partOfNodes.Clear();

            if (partOfNodes != null)
            {
                this.partOfNodes.AddAll(partOfNode);
            }
        }
        */
        
        public void SetPartOfNode(PartOfNode[] partOfNode)
        {
            this.partOfNode.Clear();

            if (partOfNode != null)
            {
                this.partOfNode.AddAll(partOfNode);
            }
        }
        

        public void SetServiceProvider(Uri serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void SetSubjects(string[] subjects)
        {
            this.subjects.Clear();

            if (subjects != null)
            {
                this.subjects.AddAll(subjects);
            }
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        #endregion SetMethod

        #region RemoveMethod

        public void RemovePartOfNode()
        {
            this.partOfNode.Clear();
        }

        #endregion RemoveMethod
    }


    [OslcNamespace(Constants.SceneGraph.SCENEGRAPH_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Scene Resource Shape", describes = new string[] { Constants.SceneGraph.TYPE_SCENEGRAPH_PART_OF })]
    public class PartOfNode : AbstractResource
    {
        #region property

        private readonly ISet<Uri> rdfTypes                             = new HashSet<Uri>();
        private readonly IList<string> allowedValues                    = new List<string>();
        private readonly ISet<string> subjects                          = new HashSet<string>();
        private readonly IList<VariantSet> variantSets                  = new List<VariantSet>();

        private Uri instanceShape;

        private ISet<Uri> isPartOf = new HashSet<Uri>();

        // 
        private RenderComponent RenderComponent;

        private TransformationGroupNode TransformationGroupNode;

        private DateTime created;
        private string title;
        private Uri serviceProvider;

        #endregion property

        #region initialization

        public PartOfNode()
            : base()
        {
            rdfTypes.Add(new Uri(Constants.SceneGraph.TYPE_SCENEGRAPH_PART_OF));
        }

        public PartOfNode(Uri about)
            : base(about)
        {
            rdfTypes.Add(new Uri(Constants.SceneGraph.TYPE_SCENEGRAPH_PART_OF));
        }

        public void AddSubject(string subject)
        {
            this.subjects.Add(subject);
        }

        public void AddPartOf(Uri isPartOfUri)
        {
            this.isPartOf.Add(isPartOfUri);
        }

        public void AddVariantSet(VariantSet variantSet)
        {
            this.variantSets.Add(variantSet);
        }

        #endregion initialization

        #region GetMethod

        [OslcDescription("Timestamp of resource creation.")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "created")]
        [OslcReadOnly]
        [OslcTitle("Created")]
        public DateTime GetCreated()
        {
            return created;
        }

        [OslcDescription("The resource type URIs.")]
        [OslcName("type")]
        [OslcPropertyDefinition(OslcConstants.RDF_NAMESPACE + "type")]
        [OslcTitle("Types")]
        public Uri[] GetRdfTypes()
        {
            return rdfTypes.ToArray();
        }

        [OslcDescription("Renderable Component")]
        [OslcPropertyDefinition(Constants.SceneGraph.SCENEGRAPH_NAMESPACE + "renderComponent")]
        [OslcOccurs(Occurs.ZeroOrOne)]
        [OslcRange(Constants.SceneGraph.TYPE_SCENEGRAPH_RENDER_COMPONENT)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("ARVIDA based Render Component")]
        public RenderComponent GetRenderComponent()
        {
            return RenderComponent;
        }

        [OslcDescription("Shows all scenegraph relations.")]
        [OslcPropertyDefinition(Constants.SceneGraph.SCENEGRAPH_NAMESPACE + "partOf")]
        [OslcOccurs(Occurs.ZeroOrMany)]
        [OslcRange(Constants.SceneGraph.TYPE_SCENEGRAPH_PART_OF)]
        [OslcTitle("ARVIDA PART OF")]
        public Uri[] GetPartOf()
        {
            return isPartOf.ToArray();
        }

        [OslcDescription("The scope of a resource is a Uri for the resource's OSLC Service Provider.")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "serviceProvider")]
        [OslcRange(OslcConstants.TYPE_SERVICE_PROVIDER)]
        [OslcTitle("Service Provider")]
        public Uri GetServiceProvider()
        {
            return serviceProvider;
        }

        [OslcDescription("Tag or keyword for a resource. Each occurrence of a dcterms:subject property denotes an additional tag for the resource.")]
        [OslcName("subject")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "subject")]
        [OslcReadOnly(false)]
        [OslcTitle("Subjects")]
        public string[] GetSubjects()
        {
            return subjects.ToArray();
        }

        [OslcDescription("Title (reference: Dublin Core) or often a single line summary of the resource represented as rich text in XHTML content.")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "title")]
        [OslcTitle("Title")]
        public string GetTitle()
        {
            return title;
        }

        [OslcDescription("TransformationGroup node relation.")]
        [OslcPropertyDefinition(Constants.SceneGraph.SCENEGRAPH_NAMESPACE + "transformationGroupNode")]
        [OslcOccurs(Occurs.ZeroOrOne)]
        [OslcRange(Constants.SceneGraph.TYPE_SCENEGRAPH_TRANSFORMATION_GROUP_NODE)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("ARVIDA TransformationGroup node")]
        public TransformationGroupNode GetTransformationGroupNode()
        {
            return TransformationGroupNode;
        }

        [OslcDescription("The Variant Sets of a Scene.")]
        [OslcName("variantSets")]
        [OslcOccurs(Occurs.OneOrMany)]
        [OslcPropertyDefinition(Constants.Scene.SCENE_NAMESPACE + "variantSets")]
        [OslcRange(Constants.Scene.TYPE_SCENE_VARIANT_SET)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        public VariantSet[] GetVariantSets()
        {
            return variantSets.ToArray();
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }

        #endregion GetMethod

        #region SetMethod

        public void SetCreated(DateTime created)
        {
            this.created = created;
        }

        public void SetRdfTypes(Uri[] rdfTypes)
        {
            this.rdfTypes.Clear();

            if (rdfTypes != null)
            {
                this.rdfTypes.AddAll(rdfTypes);
            }
        }

        public void SetRenderComponent(RenderComponent RenderComponent)
        {
            this.RenderComponent = RenderComponent;
        }

        public void SetPartOf(Uri[] isPartOf)
        {
            this.isPartOf.Clear();

            if (isPartOf != null)
            {
                this.isPartOf.AddAll(isPartOf);
            }
        }

        public void SetServiceProvider(Uri serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void SetSubjects(string[] subjects)
        {
            this.subjects.Clear();

            if (subjects != null)
            {
                this.subjects.AddAll(subjects);
            }
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetTransformationGroupNode(TransformationGroupNode transformationGroupNode)
        {
            this.TransformationGroupNode = transformationGroupNode;
        }

        public void SetVariantSets(VariantSet[] variantSets)
        {
            this.variantSets.Clear();

            if (variantSets != null)
            {
                this.variantSets.AddAll(variantSets);
            }
        }

        #endregion SetMethod
    }

    [OslcNamespace(Constants.SceneGraph.SCENEGRAPH_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Scene Resource Shape", describes = new string[] { Constants.SceneGraph.TYPE_SCENEGRAPH_RENDER_COMPONENT })]
    public class RenderComponent : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes = new HashSet<Uri>();
        private readonly IList<string> allowedValues = new List<string>();
        private readonly ISet<string> subjects = new HashSet<string>();

        private Uri instanceShape;

        private DateTime created;
        private string title;
        private Uri serviceProvider;

        public RenderComponent()
            : base()
        {
            rdfTypes.Add(new Uri(Constants.SceneGraph.TYPE_SCENEGRAPH_PART_OF));
        }

        public RenderComponent(Uri about)
            : base(about)
        {
            rdfTypes.Add(new Uri(Constants.SceneGraph.TYPE_SCENEGRAPH_PART_OF));
        }

        public void AddSubject(string subject)
        {
            this.subjects.Add(subject);
        }

        [OslcDescription("Timestamp of resource creation.")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "created")]
        [OslcReadOnly]
        [OslcTitle("Created")]
        public DateTime GetCreated()
        {
            return created;
        }

        [OslcDescription("The resource type URIs.")]
        [OslcName("type")]
        [OslcPropertyDefinition(OslcConstants.RDF_NAMESPACE + "type")]
        [OslcTitle("Types")]
        public Uri[] GetRdfTypes()
        {
            return rdfTypes.ToArray();
        }

        [OslcDescription("The scope of a resource is a Uri for the resource's OSLC Service Provider.")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "serviceProvider")]
        [OslcRange(OslcConstants.TYPE_SERVICE_PROVIDER)]
        [OslcTitle("Service Provider")]
        public Uri GetServiceProvider()
        {
            return serviceProvider;
        }

        [OslcDescription("Title (reference: Dublin Core) or often a single line summary of the resource represented as rich text in XHTML content.")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "title")]
        [OslcTitle("Title")]
        public string GetTitle()
        {
            return title;
        }

        [OslcDescription("Tag or keyword for a resource. Each occurrence of a dcterms:subject property denotes an additional tag for the resource.")]
        [OslcName("subject")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "subject")]
        [OslcReadOnly(false)]
        [OslcTitle("Subjects")]
        public string[] GetSubjects()
        {
            return subjects.ToArray();
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }

        public void SetRdfTypes(Uri[] rdfTypes)
        {
            this.rdfTypes.Clear();

            if (rdfTypes != null)
            {
                this.rdfTypes.AddAll(rdfTypes);
            }
        }

        public void SetServiceProvider(Uri serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void SetSubjects(string[] subjects)
        {
            this.subjects.Clear();

            if (subjects != null)
            {
                this.subjects.AddAll(subjects);
            }
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetCreated(DateTime created)
        {
            this.created = created;
        }
    }

    [OslcNamespace(Constants.Scene.SCENE_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Scene Resource Shape", describes = new string[] { Constants.Scene.TYPE_SCENE })]
    public class Scene : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes                             = new HashSet<Uri>();
        private readonly IList<string> allowedValues                    = new List<string>();
        private readonly ISet<string> subjects                          = new HashSet<string>();
        private readonly IList<VariantSet> VariantSets                  = new List<VariantSet>();

        private Uri instanceShape;

        private SceneNode sceneRoot;

        private DateTime created;
        private string title;
        private Uri serviceProvider;

        public Scene() : base()
        {
            rdfTypes.Add(new Uri(Constants.Scene.TYPE_SCENE));
        }

        public Scene(Uri about) : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Scene.TYPE_SCENE));
        }

        public void AddSubject(string subject)
        {
            this.subjects.Add(subject);
        }

        public void AddVariantSet(VariantSet variantSet)
        {
            this.VariantSets.Add(variantSet);
        }

        public void AddVariantSet(string        title,
                                  string[]      subjects,
                                  Uri           serviceProvider,
                                  Variant[]         variants,
                                  String        id)
        {
            VariantSet newVariantSet = new VariantSet();
            if (subjects != null)
            {
                newVariantSet.SetSubjects(subjects);
            }
            if (!string.IsNullOrEmpty(title))
            {
                newVariantSet.SetTitle(title);
            }
            if (serviceProvider != null)
            {
                newVariantSet.SetServiceProvider(serviceProvider);
            }
            if (variants != null)
            {
                foreach (Variant variant in variants)
                    newVariantSet.AddVariant(variant);
            }
            if (id != null)
            {
                newVariantSet.SetIdentifier(id);
            }

            this.VariantSets.Add(newVariantSet);
        }

        [OslcDescription("Timestamp of resource creation.")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "created")]
        [OslcReadOnly]
        [OslcTitle("Created")]
        public DateTime GetCreated()
        {
            return created;
        }

        [OslcDescription("The resource type URIs.")]
        [OslcName("type")]
        [OslcPropertyDefinition(OslcConstants.RDF_NAMESPACE + "type")]
        [OslcTitle("Types")]
        public Uri[] GetRdfTypes()
        {
            return rdfTypes.ToArray();
        }

        [OslcDescription("The scope of a resource is a Uri for the resource's OSLC Service Provider.")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "serviceProvider")]
        [OslcRange(OslcConstants.TYPE_SERVICE_PROVIDER)]
        [OslcTitle("Service Provider")]
        public Uri GetServiceProvider()
        {
            return serviceProvider;
        }

        [OslcDescription("The Variant Sets of a Scene.")]
        [OslcName("variantSets")]
        [OslcOccurs(Occurs.OneOrMany)]
        [OslcPropertyDefinition(Constants.Scene.SCENE_NAMESPACE + "variantSets")]
        [OslcRange(Constants.Scene.TYPE_SCENE_VARIANT_SET)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        public VariantSet[] GetVariantSets()
        {
            return VariantSets.ToArray();
        }

        [OslcDescription("The scene root node.")]
        [OslcName("sceneRoot")]
        [OslcOccurs(Occurs.ZeroOrOne)]
        [OslcPropertyDefinition(Constants.SceneGraph.SCENEGRAPH_NAMESPACE + "sceneRoot")]
        [OslcRange(Constants.SceneGraph.TYPE_SCENEGRAPH_SCENE_NODE)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        public SceneNode GetSceneRoot()
        {
            return sceneRoot;
        }

        [OslcDescription("Title (reference: Dublin Core) or often a single line summary of the resource represented as rich text in XHTML content.")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "title")]
        [OslcTitle("Title")]
        public string GetTitle()
        {
            return title;
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }

        public void SetRdfTypes(Uri[] rdfTypes)
        {
            this.rdfTypes.Clear();

            if (rdfTypes != null)
            {
                this.rdfTypes.AddAll(rdfTypes);
            }
        }

        public void SetServiceProvider(Uri serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void SetSubjects(string[] subjects)
        {
            this.subjects.Clear();

            if (subjects != null)
            {
                this.subjects.AddAll(subjects);
            }
        }

        public void SetVariantSets(VariantSet[] variantSets)
        {
            this.VariantSets.Clear();

            if (variantSets != null)
            {
                this.VariantSets.AddAll(variantSets);
            }
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetSceneRoot(SceneNode sceneRoot)
        {
            this.sceneRoot = sceneRoot;
        }

        public void SetCreated(DateTime created)
        {
            this.created = created;
        }
    }

    [OslcNamespace(Constants.Maths.MATHS_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Math Resource Shape", describes = new string[] { Constants.Maths.TYPE_X })]
    public class X : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes = new HashSet<Uri>();
        private Double x;
        private Uri instanceShape;

        public X() : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_X));
        }

        public X(Double x) : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_X));
            this.x = x;
        }

        public X(Double x, Uri about) : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_X));
            this.x = x;
        }

        public void AddRdfType(Uri rdfType)
        {
            this.rdfTypes.Add(rdfType);
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        [OslcDescription("ARVIDA object")]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Double)]
        [OslcName("double")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.XML_NAMESPACE + "double")]
        [OslcTitle("The property 'x' associates a double value as x-component to its subject")]
        public Double GetX()
        {
            return this.x;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }

        public void SetX(Double x)
        {
            this.x = x;
        }
    }

    [OslcNamespace(Constants.Maths.MATHS_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Math Resource Shape", describes = new string[] { Constants.Maths.TYPE_Y })]
    public class Y : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes = new HashSet<Uri>();
        private Double y;
        private Uri instanceShape;

        public Y() : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_Y));
        }

        public Y(Double y) : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_Y));
            this.y = y;
        }

        public Y(Double y, Uri about) : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_Y));
            this.y = y;
        }

        public void AddRdfType(Uri rdfType)
        {
            this.rdfTypes.Add(rdfType);
        }

        [OslcDescription("ARVIDA object")]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Double)]
        [OslcName("double")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.XML_NAMESPACE + "double")]
        [OslcTitle("The property 'y' associates a double value as y-component to its subject")]
        public Double GetY()
        {
            return this.y;
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }

        public void SetY(Double y)
        {
            this.y = y;
        }
    }

    [OslcNamespace(Constants.Maths.MATHS_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Math Resource Shape", describes = new string[] { Constants.Maths.TYPE_Z })]
    public class Z : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes = new HashSet<Uri>();
        private Double z;
        private Uri instanceShape;

        public Z() : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_Z));
        }

        public Z(Double z) : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_Z));
            this.z = z;
        }

        public Z(Double z, Uri about) : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_Z));
            this.z = z;
        }

        public void AddRdfType(Uri rdfType)
        {
            this.rdfTypes.Add(rdfType);
        }

        [OslcDescription("ARVIDA object")]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Double)]
        [OslcName("double")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.XML_NAMESPACE + "double")]
        [OslcTitle("The property 'z' associates a double value as z-component to its subject")]
        public Double GetZ()
        {
            return this.z;
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }

        public void SetZ(Double z)
        {
            this.z = z;
        }
    }

    [OslcNamespace(Constants.Maths.MATHS_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Math Resource Shape", describes = new string[] { Constants.Maths.TYPE_A_11 })]
    public class A11 : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes = new HashSet<Uri>();
        private Double thisValue;

        private Uri instanceShape;


        public A11() : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_11));
        }

            public A11(Double thisValue) : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_11));
            this.thisValue = thisValue;
        }

        public A11(Double thisValue, Uri about) : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_11));
            this.thisValue = thisValue;
        }

        public void AddRdfType(Uri rdfType)
        {
            this.rdfTypes.Add(rdfType);
        }

        [OslcDescription("ARVIDA object")]
        [OslcName("double")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.XML_NAMESPACE + "double")]
        [OslcTitle("The property 'a11' associates a double value as the entry in the 1st row and 1st column of to its subject.")]
        public Double GetValue()
        {
            return this.thisValue;
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }

        public void SetValue(Double thisValue)
        {
            this.thisValue = thisValue;
        }
    }

    [OslcNamespace(Constants.Maths.MATHS_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Math Resource Shape", describes = new string[] { Constants.Maths.TYPE_A_12 })]
    public class A12 : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes = new HashSet<Uri>();
        private Double thisValue;

        private Uri instanceShape;


        public A12() : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_12));
        }

        public A12(Double thisValue) : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_12));
            this.thisValue = thisValue;
        }

        public A12(Double thisValue, Uri about) : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_12));
            this.thisValue = thisValue;
        }

        public void AddRdfType(Uri rdfType)
        {
            this.rdfTypes.Add(rdfType);
        }

        [OslcDescription("ARVIDA object")]
        [OslcName("double")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.XML_NAMESPACE + "double")]
        [OslcTitle("The property 'a12' associates a double value as the entry in the 1st row and 2st column of to its subject.")]
        public Double GetValue()
        {
            return this.thisValue;
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }

        public void SetValue(Double thisValue)
        {
            this.thisValue = thisValue;
        }
    }

    [OslcNamespace(Constants.Maths.MATHS_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Math Resource Shape", describes = new string[] { Constants.Maths.TYPE_A_13 })]
    public class A13 : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes = new HashSet<Uri>();
        private Double thisValue;

        private Uri instanceShape;


        public A13() : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_13));
        }

        public A13(Double thisValue) : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_13));
            this.thisValue = thisValue;
        }

        public A13(Double thisValue, Uri about) : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_13));
            this.thisValue = thisValue;
        }

        public void AddRdfType(Uri rdfType)
        {
            this.rdfTypes.Add(rdfType);
        }

        [OslcDescription("ARVIDA object")]
        [OslcName("double")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.XML_NAMESPACE + "double")]
        [OslcTitle("The property 'a13' associates a double value as the entry in the 1st row and 3st column of to its subject.")]
        public Double GetValue()
        {
            return this.thisValue;
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }

        public void SetValue(Double thisValue)
        {
            this.thisValue = thisValue;
        }
    }

    [OslcNamespace(Constants.Maths.MATHS_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Math Resource Shape", describes = new string[] { Constants.Maths.TYPE_A_21 })]
    public class A21 : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes = new HashSet<Uri>();
        private Double thisValue;

        private Uri instanceShape;


        public A21() : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_21));
        }

        public A21(Double thisValue) : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_21));
            this.thisValue = thisValue;
        }

        public A21(Double thisValue, Uri about) : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_21));
            this.thisValue = thisValue;
        }

        public void AddRdfType(Uri rdfType)
        {
            this.rdfTypes.Add(rdfType);
        }

        [OslcDescription("ARVIDA object")]
        [OslcName("double")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.XML_NAMESPACE + "double")]
        [OslcTitle("The property 'a21' associates a double value as the entry in the 2st row and 1st column of to its subject.")]
        public Double GetValue()
        {
            return this.thisValue;
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }

        public void SetValue(Double thisValue)
        {
            this.thisValue = thisValue;
        }
    }

    [OslcNamespace(Constants.Maths.MATHS_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Math Resource Shape", describes = new string[] { Constants.Maths.TYPE_A_22 })]
    public class A22 : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes = new HashSet<Uri>();
        private Double thisValue;

        private Uri instanceShape;

        public A22() : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_22));
        }

        public A22(Double thisValue) : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_22));
            this.thisValue = thisValue;
        }

        public A22(Double thisValue, Uri about) : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_22));
            this.thisValue = thisValue;
        }

        public void AddRdfType(Uri rdfType)
        {
            this.rdfTypes.Add(rdfType);
        }

        [OslcDescription("ARVIDA object")]
        [OslcName("double")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.XML_NAMESPACE + "double")]
        [OslcTitle("The property 'a22' associates a double value as the entry in the 2st row and 2st column of to its subject.")]
        public Double GetValue()
        {
            return this.thisValue;
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }

        public void SetValue(Double thisValue)
        {
            this.thisValue = thisValue;
        }
    }

    [OslcNamespace(Constants.Maths.MATHS_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Math Resource Shape", describes = new string[] { Constants.Maths.TYPE_A_23 })]
    public class A23 : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes = new HashSet<Uri>();
        private Double thisValue;

        private Uri instanceShape;


        public A23() : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_23));
        }

        public A23(Double thisValue) : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_23));
            this.thisValue = thisValue;
        }

        public A23(Double thisValue, Uri about) : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_23));
            this.thisValue = thisValue;
        }

        public void AddRdfType(Uri rdfType)
        {
            this.rdfTypes.Add(rdfType);
        }

        [OslcDescription("ARVIDA object")]
        [OslcName("double")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.XML_NAMESPACE + "double")]
        [OslcTitle("The property 'a23' associates a double value as the entry in the 2st row and 3st column of to its subject.")]
        public Double GetValue()
        {
            return this.thisValue;
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }

        public void SetValue(Double thisValue)
        {
            this.thisValue = thisValue;
        }
    }

    [OslcNamespace(Constants.Maths.MATHS_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Math Resource Shape", describes = new string[] { Constants.Maths.TYPE_A_31 })]
    public class A31 : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes = new HashSet<Uri>();
        private Double thisValue;

        private Uri instanceShape;


        public A31() : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_31));
        }

        public A31(Double thisValue) : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_31));
            this.thisValue = thisValue;
        }

        public A31(Double thisValue, Uri about) : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_31));
            this.thisValue = thisValue;
        }

        public void AddRdfType(Uri rdfType)
        {
            this.rdfTypes.Add(rdfType);
        }

        [OslcDescription("ARVIDA object")]
        [OslcName("double")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.XML_NAMESPACE + "double")]
        [OslcTitle("The property 'a31' associates a double value as the entry in the 3st row and 1st column of to its subject.")]
        public Double GetValue()
        {
            return this.thisValue;
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }

        public void SetValue(Double thisValue)
        {
            this.thisValue = thisValue;
        }
    }

    [OslcNamespace(Constants.Maths.MATHS_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Math Resource Shape", describes = new string[] { Constants.Maths.TYPE_A_32 })]
    public class A32 : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes = new HashSet<Uri>();
        private Double thisValue;

        private Uri instanceShape;


        public A32() : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_32));
        }

        public A32(Double thisValue) : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_32));
            this.thisValue = thisValue;
        }

        public A32(Double thisValue, Uri about) : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_32));
            this.thisValue = thisValue;
        }

        public void AddRdfType(Uri rdfType)
        {
            this.rdfTypes.Add(rdfType);
        }

        [OslcDescription("ARVIDA object")]
        [OslcName("double")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.XML_NAMESPACE + "double")]
        [OslcTitle("The property 'a32' associates a double value as the entry in the 3st row and 2st column of to its subject.")]
        public Double GetValue()
        {
            return this.thisValue;
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }

        public void SetValue(Double thisValue)
        {
            this.thisValue = thisValue;
        }
    }

    [OslcNamespace(Constants.Maths.MATHS_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Math Resource Shape", describes = new string[] { Constants.Maths.TYPE_A_33 })]
    public class A33 : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes = new HashSet<Uri>();
        private Double thisValue;

        private Uri instanceShape;


        public A33() : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_33));
        }

        public A33(Double thisValue) : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_33));
            this.thisValue = thisValue;
        }

        public A33(Double thisValue, Uri about) : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_A_33));
            this.thisValue = thisValue;
        }

        public void AddRdfType(Uri rdfType)
        {
            this.rdfTypes.Add(rdfType);
        }

        [OslcDescription("ARVIDA object")]
        [OslcName("double")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.XML_NAMESPACE + "double")]
        [OslcTitle("The property 'a33' associates a double value as the entry in the 3st row and 3st column of to its subject.")]
        public Double GetValue()
        {
            return this.thisValue;
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }

        public void SetValue(Double thisValue)
        {
            this.thisValue = thisValue;
        }
    }

    [OslcNamespace(Constants.Maths.MATHS_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Math Resource Shape", describes = new string[] { Constants.Maths.TYPE_3D_VECTOR})]
    public class Vector3D : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes = new HashSet<Uri>();
        private readonly IList<string> allowedValues = new List<string>();
        private Uri instanceShape;


        private X x;
        private Y y;
        private Z z;

        public Vector3D() : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_3D_VECTOR));
        }

        public Vector3D(Uri about) : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_3D_VECTOR));
        }

        public Vector3D(X x, Y y, Z z) : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_3D_VECTOR));
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3D(X x, Y y, Z z, Uri about) : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_3D_VECTOR));
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void AddRdfType(Uri rdfType)
        {
            this.rdfTypes.Add(rdfType);
        }

        public void SetXYZ(X x, Y y, Z z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        [OslcDescription("ARVIDA object")]
        [OslcName("x")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcReadOnly(false)]
        [OslcPropertyDefinition(Constants.Maths.MATHS_NAMESPACE + "x")]
        [OslcRange(Constants.Maths.TYPE_X)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("The property 'x' associates a double value as x-component to its subject")]
        public X GetX()
        {
            return this.x;
        }

        [OslcDescription("ARVIDA object")]
        [OslcName("y")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcReadOnly(false)]
        [OslcPropertyDefinition(Constants.Maths.MATHS_NAMESPACE + "y")]
        [OslcRange(Constants.Maths.TYPE_Y)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("The property 'y' associates a double value as y-component to its subject")]
        public Y GetY()
        {
            return this.y;
        }

        [OslcDescription("ARVIDA object")]
        [OslcName("z")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcReadOnly(false)]
        [OslcPropertyDefinition(Constants.Maths.MATHS_NAMESPACE + "z")]
        [OslcRange(Constants.Maths.TYPE_Z)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("The property 'z' associates a double value as z-component to its subject")]
        public Z GetZ()
        {
            return this.z;
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }

        public void SetX(X x)
        {
            this.x = x;
        }

        public void SetY(Y y)
        {
            this.y = y;
        }

        public void SetZ(Z z)
        {
            this.z = z;
        }
    }

    [OslcNamespace(Constants.Maths.MATHS_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Math Resource Shape", describes = new string[] { Constants.Maths.TYPE_3D_MATRIX })]
    public class Matrix3D : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes = new HashSet<Uri>();
        private readonly IList<string> allowedValues = new List<string>();
        private Uri instanceShape;


        private A11 A11;
        private A12 A12;
        private A13 A13;
        private A21 A21;
        private A22 A22;
        private A23 A23;
        private A31 A31;
        private A32 A32;
        private A33 A33;

        public Matrix3D() : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_3D_MATRIX));
        }

        public Matrix3D(Uri about) : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_3D_MATRIX));
        }

        public Matrix3D(A11 A11,
                        A12 A12,
                        A13 A13,
                        A21 A21,
                        A22 A22,
                        A23 A23,
                        A31 A31,
                        A32 A32,
                        A33 A33) : base()
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_3D_MATRIX));
            this.A11 = A11;
            this.A12 = A12;
            this.A13 = A13;
            this.A21 = A21;
            this.A22 = A22;
            this.A23 = A23;
            this.A31 = A31;
            this.A32 = A32;
            this.A33 = A33;
        }

        public Matrix3D(A11 A11,
                        A12 A12,
                        A13 A13,
                        A21 A21,
                        A22 A22,
                        A23 A23,
                        A31 A31,
                        A32 A32,
                        A33 A33,
                        Uri about) : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Maths.TYPE_3D_MATRIX));
            this.A11 = A11;
            this.A12 = A12;
            this.A13 = A13;
            this.A21 = A21;
            this.A22 = A22;
            this.A23 = A23;
            this.A31 = A31;
            this.A32 = A32;
            this.A33 = A33;
        }

        public void AddRdfType(Uri rdfType)
        {
            this.rdfTypes.Add(rdfType);
        }

        public void SetMatrixValues(A11 A11,
                                    A12 A12,
                                    A13 A13,
                                    A21 A21,
                                    A22 A22,
                                    A23 A23,
                                    A31 A31,
                                    A32 A32,
                                    A33 A33)
        {
            this.A11 = A11;
            this.A12 = A12;
            this.A13 = A13;
            this.A21 = A21;
            this.A22 = A22;
            this.A23 = A23;
            this.A31 = A31;
            this.A32 = A32;
            this.A33 = A33;
        }

        [OslcDescription("ARVIDA object")]
        [OslcName("a11")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcReadOnly(false)]
        [OslcPropertyDefinition(Constants.Maths.MATHS_NAMESPACE + "a11")]
        [OslcRange(Constants.Maths.TYPE_A_11)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("The property 'a11' associates a double value as the entry in the 1st row and 1nd column of to its subject.")]
        public A11 GetA11()
        {
            return this.A11;
        }

        [OslcDescription("ARVIDA object")]
        [OslcName("a12")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcReadOnly(false)]
        [OslcPropertyDefinition(Constants.Maths.MATHS_NAMESPACE + "a12")]
        [OslcRange(Constants.Maths.TYPE_A_12)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("The property 'a12' associates a double value as the entry in the 1st row and 2nd column of to its subject.")]
        public A12 GetA12()
        {
            return this.A12;
        }

        [OslcDescription("ARVIDA object")]
        [OslcName("a13")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcReadOnly(false)]
        [OslcPropertyDefinition(Constants.Maths.MATHS_NAMESPACE + "a13")]
        [OslcRange(Constants.Maths.TYPE_A_13)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("The property 'a13' associates a double value as the entry in the 1st row and 3nd column of to its subject.")]
        public A13 GetA13()
        {
            return this.A13;
        }

        [OslcDescription("ARVIDA object")]
        [OslcName("a21")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcReadOnly(false)]
        [OslcPropertyDefinition(Constants.Maths.MATHS_NAMESPACE + "a21")]
        [OslcRange(Constants.Maths.TYPE_A_21)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("The property 'a21' associates a double value as the entry in the 2st row and 1nd column of to its subject.")]
        public A21 GetA21()
        {
            return this.A21;
        }

        [OslcDescription("ARVIDA object")]
        [OslcName("a22")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcReadOnly(false)]
        [OslcPropertyDefinition(Constants.Maths.MATHS_NAMESPACE + "a22")]
        [OslcRange(Constants.Maths.TYPE_A_22)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("The property 'a22' associates a double value as the entry in the 2st row and 2nd column of to its subject.")]
        public A22 GetA22()
        {
            return this.A22;
        }

        [OslcDescription("ARVIDA object")]
        [OslcName("a23")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcReadOnly(false)]
        [OslcPropertyDefinition(Constants.Maths.MATHS_NAMESPACE + "a23")]
        [OslcRange(Constants.Maths.TYPE_A_23)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("The property 'a23' associates a double value as the entry in the 2st row and 3nd column of to its subject.")]
        public A23 GetA23()
        {
            return this.A23;
        }

        [OslcDescription("ARVIDA object")]
        [OslcName("a31")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcReadOnly(false)]
        [OslcPropertyDefinition(Constants.Maths.MATHS_NAMESPACE + "a31")]
        [OslcRange(Constants.Maths.TYPE_A_31)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("The property 'a31' associates a double value as the entry in the 3st row and 1nd column of to its subject.")]
        public A31 GetA31()
        {
            return this.A31;
        }

        [OslcDescription("ARVIDA object")]
        [OslcName("a32")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcReadOnly(false)]
        [OslcPropertyDefinition(Constants.Maths.MATHS_NAMESPACE + "a32")]
        [OslcRange(Constants.Maths.TYPE_A_32)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("The property 'a32' associates a double value as the entry in the 3st row and 2nd column of to its subject.")]
        public A32 GetA32()
        {
            return this.A32;
        }

        [OslcDescription("ARVIDA object")]
        [OslcName("a33")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcReadOnly(false)]
        [OslcPropertyDefinition(Constants.Maths.MATHS_NAMESPACE + "a33")]
        [OslcRange(Constants.Maths.TYPE_A_33)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("The property 'a33' associates a double value as the entry in the 3st row and 3nd column of to its subject.")]
        public A33 GetA33()
        {
            return this.A33;
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }


        public void SetA11(A11 thisValue)
        {
            this.A11 = thisValue;
        }

        public void SetA12(A12 thisValue)
        {
            this.A12 = thisValue;
        }

        public void SetA13(A13 thisValue)
        {
            this.A13 = thisValue;
        }

        public void SetA21(A21 thisValue)
        {
            this.A21 = thisValue;
        }

        public void SetA22(A22 thisValue)
        {
            this.A22 = thisValue;
        }

        public void SetA23(A23 thisValue)
        {
            this.A23 = thisValue;
        }

        public void SetA31(A31 thisValue)
        {
            this.A31 = thisValue;
        }

        public void SetA32(A32 thisValue)
        {
            this.A32 = thisValue;
        }

        public void SetA33(A33 thisValue)
        {
            this.A33 = thisValue;
        }
    }

    [OslcNamespace(Constants.Spartial.SPARTIAL_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Spartial Resource Shape", describes = new string[] { Constants.Spartial.TYPE_SPARTIAL_3D_TRANSLATION })]
    public class Translation3D : AbstractResource
    {
        private readonly ISet<Uri>              rdfTypes                = new HashSet<Uri>();
        private readonly IList<string>          allowedValues           = new List<string>();
        private readonly ISet<string>           subjects                = new HashSet<string>();

        private DateTime                       created;
        private string                          title;
        private Uri                             serviceProvider;
        private Uri instanceShape;


        // Transformation Value 
        private Vector3D Vector3D;

        public Translation3D() : base()
        {
            rdfTypes.Add(new Uri(Constants.Spartial.TYPE_SPARTIAL_3D_TRANSLATION));
        }

        public Translation3D(Uri about) : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Spartial.TYPE_SPARTIAL_3D_TRANSLATION));
        }

        public Translation3D(Vector3D vector3D) : base()
        {
            rdfTypes.Add(new Uri(Constants.Spartial.TYPE_SPARTIAL_3D_TRANSLATION));
            this.Vector3D = vector3D;
        }

        public Translation3D(Vector3D vector3D, Uri about) : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Spartial.TYPE_SPARTIAL_3D_TRANSLATION));
            this.Vector3D = vector3D;
        }

        public void AddRdfType(Uri rdfType)
        {
            this.rdfTypes.Add(rdfType);
        }

        public void AddSubject(string subject)
        {
            this.subjects.Add(subject);
        }

        [OslcDescription("Timestamp of resource creation.")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "created")]
        [OslcReadOnly]
        [OslcTitle("Created")]
        public DateTime GetCreated()
        {
            return created;
        }

        [OslcDescription("The resource type URIs.")]
        [OslcName("type")]
        [OslcPropertyDefinition(OslcConstants.RDF_NAMESPACE + "type")]
        [OslcTitle("Types")]
        public Uri[] GetRdfTypes()
        {
            return rdfTypes.ToArray();
        }

        [OslcDescription("The scope of a resource is a Uri for the resource's OSLC Service Provider.")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "serviceProvider")]
        [OslcRange(OslcConstants.TYPE_SERVICE_PROVIDER)]
        [OslcTitle("Service Provider")]
        public Uri GetServiceProvider()
        {
            return serviceProvider;
        }

        [OslcDescription("Tag or keyword for a resource. Each occurrence of a dcterms:subject property denotes an additional tag for the resource.")]
        [OslcName("subject")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "subject")]
        [OslcReadOnly(false)]
        [OslcTitle("Subjects")]
        public string[] GetSubjects()
        {
            return subjects.ToArray();
        }

        [OslcDescription("Title (reference: Dublin Core) or often a single line summary of the resource represented as rich text in XHTML content.")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "title")]
        [OslcTitle("Title")]
        public string GetTitle()
        {
            return title;
        }
        
        [OslcDescription("ARVIDA object")]
        [OslcName("vector3D")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcReadOnly(false)]
        [OslcPropertyDefinition(Constants.Maths.MATHS_NAMESPACE + "vector3D")]
        [OslcRange(Constants.Maths.TYPE_3D_VECTOR)]
        [OslcTitle("ARVIDA SPARTIAL 3D Translation")]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        public Vector3D GetVector3D()
        {
            return Vector3D;
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }


        public void SetRdfTypes(Uri[] rdfTypes)
        {
            this.rdfTypes.Clear();

            if (rdfTypes != null)
            {
                this.rdfTypes.AddAll(rdfTypes);
            }
        }

        public void SetServiceProvider(Uri serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void SetSubjects(string[] subjects)
        {
            this.subjects.Clear();

            if (subjects != null)
            {
                this.subjects.AddAll(subjects);
            }
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetVector3D(Vector3D vector3D)
        {
            this.Vector3D = vector3D;
        }        

        public void SetCreated(DateTime created)
        {
            this.created = created;
        }
    }

    [OslcNamespace(Constants.Spartial.SPARTIAL_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Spartial Resource Shape", describes = new string[] { Constants.Spartial.TYPE_SPARTIAL_3D_ROTATION })]
    public class  Rotation3D: AbstractResource
    {
        private readonly ISet<Uri>              rdfTypes                = new HashSet<Uri>();
        private readonly IList<string>          allowedValues           = new List<string>();
        private readonly ISet<string>           subjects                = new HashSet<string>();

        private DateTime                       created;
        private string                          title;
        private Uri                             serviceProvider;
        private Uri instanceShape;


        // Transformation Values for rotation
        private Matrix3D                        matrix3D;


        public Rotation3D() : base()
        {
            rdfTypes.Add(new Uri(Constants.Spartial.TYPE_SPARTIAL_3D_ROTATION));
        }

        public Rotation3D(Uri about)
            : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Spartial.TYPE_SPARTIAL_3D_ROTATION));
        }

        public Rotation3D(Matrix3D matrix3D) : base()
        {
            rdfTypes.Add(new Uri(Constants.Spartial.TYPE_SPARTIAL_3D_ROTATION));
            this.matrix3D = matrix3D;
        }

        public Rotation3D(Matrix3D matrix3D, Uri about)
            : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Spartial.TYPE_SPARTIAL_3D_ROTATION));
            this.matrix3D = matrix3D;
        }

        public void SetMatrix3D(Matrix3D matrix3D)
        {
            this.matrix3D = matrix3D;
        }

        public void AddRdfType(Uri rdfType)
        {
            this.rdfTypes.Add(rdfType);
        }

        public void AddSubject(string subject)
        {
            this.subjects.Add(subject);
        }

        [OslcDescription("Timestamp of resource creation.")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "created")]
        [OslcReadOnly]
        [OslcTitle("Created")]
        public DateTime GetCreated()
        {
            return created;
        }

        [OslcDescription("The resource type URIs.")]
        [OslcName("type")]
        [OslcPropertyDefinition(OslcConstants.RDF_NAMESPACE + "type")]
        [OslcTitle("Types")]
        public Uri[] GetRdfTypes()
        {
            return rdfTypes.ToArray();
        }

        [OslcDescription("The scope of a resource is a Uri for the resource's OSLC Service Provider.")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "serviceProvider")]
        [OslcRange(OslcConstants.TYPE_SERVICE_PROVIDER)]
        [OslcTitle("Service Provider")]
        public Uri GetServiceProvider()
        {
            return serviceProvider;
        }

        [OslcDescription("Tag or keyword for a resource. Each occurrence of a dcterms:subject property denotes an additional tag for the resource.")]
        [OslcName("subject")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "subject")]
        [OslcReadOnly(false)]
        [OslcTitle("Subjects")]
        public string[] GetSubjects()
        {
            return subjects.ToArray();
        }

        [OslcDescription("Title (reference: Dublin Core) or often a single line summary of the resource represented as rich text in XHTML content.")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "title")]
        [OslcTitle("Title")]
        public string GetTitle()
        {
            return title;
        }

        [OslcDescription("ARVIDA derived object")]
        [OslcName("matrix3D")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcReadOnly(false)]
        [OslcPropertyDefinition(Constants.Maths.MATHS_NAMESPACE + "matrix3D")]
        [OslcRange(Constants.Maths.TYPE_3D_MATRIX)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("ARVIDA SPARTIAL 3D Rotation matrix")]
        public Matrix3D GetMatrix3D()
        {
            return this.matrix3D;
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }


        public void SetRdfTypes(Uri[] rdfTypes)
        {
            this.rdfTypes.Clear();

            if (rdfTypes != null)
            {
                this.rdfTypes.AddAll(rdfTypes);
            }
        }

        public void SetServiceProvider(Uri serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void SetSubjects(string[] subjects)
        {
            this.subjects.Clear();

            if (subjects != null)
            {
                this.subjects.AddAll(subjects);
            }
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetCreated(DateTime created)
        {
            this.created = created;
        }
    }

    [OslcNamespace(Constants.Scene.SCENE_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Scene Resource Shape", describes = new string[] { Constants.Scene.TYPE_SCENE_TRIGGERABLE_ELEMENT })]
    public class TriggerableElement : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes = new HashSet<Uri>();
        private readonly ISet<string> subjects = new HashSet<string>();
        private Uri instanceShape;


        private string identifier;
        private DateTime created;
        private string title;
        private Uri serviceProvider;
        private DateTime modified;
        private Specification specification;

        public TriggerableElement()
            : base()
        {
            rdfTypes.Add(new Uri(Constants.Scene.TYPE_SCENE_VARIANT));
        }

        public TriggerableElement(Uri about)
            : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Scene.TYPE_SCENE_VARIANT));
        }

        public void AddRdfType(Uri rdfType)
        {
            this.rdfTypes.Add(rdfType);
        }

        public void AddSubject(string subject)
        {
            this.subjects.Add(subject);
        }

        [OslcDescription("A unique identifier for a resource. Assigned by the service provider when a resource is created. Not intended for end-user display.")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "identifier")]
        [OslcReadOnly]
        [OslcTitle("Identifier")]
        public string GetIdentifier()
        {
            return identifier;
        }

        [OslcDescription("Timestamp of resource creation.")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "created")]
        [OslcReadOnly]
        [OslcTitle("Created")]
        public DateTime GetCreated()
        {
            return created;
        }

        [OslcDescription("Timestamp last latest resource modification.")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "modified")]
        [OslcReadOnly]
        [OslcTitle("Modified")]
        public DateTime GetModified()
        {
            return modified;
        }

        [OslcDescription("The resource type URIs.")]
        [OslcName("type")]
        [OslcPropertyDefinition(OslcConstants.RDF_NAMESPACE + "type")]
        [OslcTitle("Types")]
        public Uri[] GetRdfTypes()
        {
            return rdfTypes.ToArray();
        }

        [OslcDescription("The scope of a resource is a Uri for the resource's OSLC Service Provider.")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "serviceProvider")]
        [OslcRange(OslcConstants.TYPE_SERVICE_PROVIDER)]
        [OslcTitle("Service Provider")]
        public Uri GetServiceProvider()
        {
            return serviceProvider;
        }

        [OslcDescription("Tag or keyword for a resource. Each occurrence of a dcterms:subject property denotes an additional tag for the resource.")]
        [OslcName("subject")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "subject")]
        [OslcReadOnly(false)]
        [OslcTitle("Subjects")]
        public string[] GetSubjects()
        {
            return subjects.ToArray();
        }

        [OslcDescription("Title (reference: Dublin Core) or often a single line summary of the resource represented as rich text in XHTML content.")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "title")]
        [OslcTitle("Title")]
        public string GetTitle()
        {
            return title;
        }

        [OslcDescription("A Specification is a characteristic of a product, discriminates one product from other members.")]
        [OslcName("specification")]
        [OslcOccurs(Occurs.ZeroOrOne)]
        [OslcReadOnly(false)]
        [OslcPropertyDefinition(Constants.plm.PLM_NAMESPACE + "specification")]
        [OslcRange(Constants.plm.TYPE_SPECIFICATION)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("PLM related specification of a variant, which discriminates on variant from other available varaints of a variant set")]
        public Specification GetSpecification()
        {
            return specification;
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }


        public void SetIdentifier(string identifier)
        {
            this.identifier = identifier;
        }

        public void SetSpecification(Specification specification)
        {
            this.specification = specification;
        }

        public void SetModified(DateTime modified)
        {
            this.modified = modified;
        }

        public void SetRdfTypes(Uri[] rdfTypes)
        {
            this.rdfTypes.Clear();

            if (rdfTypes != null)
            {
                this.rdfTypes.AddAll(rdfTypes);
            }
        }

        public void SetServiceProvider(Uri serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void SetSubjects(string[] subjects)
        {
            this.subjects.Clear();

            if (subjects != null)
            {
                this.subjects.AddAll(subjects);
            }
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetCreated(DateTime created)
        {
            this.created = created;
        }

        public void SetCreated()
        {
            this.created = DateTime.Now;
        }
    }

    [OslcNamespace(Constants.Scene.SCENE_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Scene Resource Shape", describes = new string[] { Constants.Scene.TYPE_SCENE_VARIANT_SET })]
    public class TriggerableElementContainer : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes = new HashSet<Uri>();
        private readonly ISet<string> subjects = new HashSet<string>();
        private readonly IList<TriggerableElement> triggerableElements = new List<TriggerableElement>();
        private Uri instanceShape;


        private string identifier;
        private DateTime created;
        private string title;
        private Uri serviceProvider;
        private DateTime modified;

        public TriggerableElementContainer() : base()
        {
            rdfTypes.Add(new Uri(Constants.Scene.TYPE_SCENE_VARIANT_SET));
        }

        public TriggerableElementContainer(Uri about) : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Scene.TYPE_SCENE_VARIANT_SET));
        }

        public void AddRdfType(Uri rdfType)
        {
            this.rdfTypes.Add(rdfType);
        }

        public void AddSubject(string subject)
        {
            this.subjects.Add(subject);
        }

        public void AddVariant(TriggerableElement triggerableElement)
        {
            this.triggerableElements.Add(triggerableElement);
        }

        [OslcDescription("A unique identifier for a resource. Assigned by the service provider when a resource is created. Not intended for end-user display.")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "identifier")]
        [OslcReadOnly]
        [OslcTitle("Identifier")]
        public string GetIdentifier()
        {
            return identifier;
        }

        [OslcDescription("Timestamp of resource creation.")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "created")]
        [OslcReadOnly]
        [OslcTitle("Created")]
        public DateTime GetCreated()
        {
            return created;
        }

        [OslcDescription("Timestamp last latest resource modification.")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "modified")]
        [OslcReadOnly]
        [OslcTitle("Modified")]
        public DateTime GetModified()
        {
            return modified;
        }

        [OslcDescription("The resource type URIs.")]
        [OslcName("type")]
        [OslcPropertyDefinition(OslcConstants.RDF_NAMESPACE + "type")]
        [OslcTitle("Types")]
        public Uri[] GetRdfTypes()
        {
            return rdfTypes.ToArray();
        }

        [OslcDescription("The scope of a resource is a Uri for the resource's OSLC Service Provider.")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "serviceProvider")]
        [OslcRange(OslcConstants.TYPE_SERVICE_PROVIDER)]
        [OslcTitle("Service Provider")]
        public Uri GetServiceProvider()
        {
            return serviceProvider;
        }

        [OslcDescription("Tag or keyword for a resource. Each occurrence of a dcterms:subject property denotes an additional tag for the resource.")]
        [OslcName("subject")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "subject")]
        [OslcReadOnly(false)]
        [OslcTitle("Subjects")]
        public string[] GetSubjects()
        {
            return subjects.ToArray();
        }

        [OslcDescription("Title (reference: Dublin Core) or often a single line summary of the resource represented as rich text in XHTML content.")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "title")]
        [OslcTitle("Title")]
        public string GetTitle()
        {
            return title;
        }

        [OslcDescription("ARVIDA derived object")]
        [OslcOccurs(Occurs.OneOrMany)]
        [OslcReadOnly(false)]
        [OslcPropertyDefinition(Constants.Scene.SCENE_NAMESPACE + "triggerableElement")]
        [OslcRange(Constants.Scene.TYPE_SCENE_TRIGGERABLE_ELEMENT)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("VisID - ARVIDA derived variant set")]
        public TriggerableElement[] GetTriggerableElement()
        {
            return triggerableElements.ToArray();
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }


        public void SetIdentifier(string identifier)
        {
            this.identifier = identifier;
        }

        public void SetModified(DateTime modified)
        {
            this.modified = modified;
        }

        public void SetRdfTypes(Uri[] rdfTypes)
        {
            this.rdfTypes.Clear();

            if (rdfTypes != null)
            {
                this.rdfTypes.AddAll(rdfTypes);
            }
        }

        public void SetTriggerableElement(TriggerableElement[] triggerableElements)
        {
            this.triggerableElements.Clear();

            if (triggerableElements != null)
            {
                this.triggerableElements.AddAll(triggerableElements);
            }
        }

        public void SetServiceProvider(Uri serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void SetSubjects(string[] subjects)
        {
            this.subjects.Clear();

            if (subjects != null)
            {
                this.subjects.AddAll(subjects);
            }
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetCreated(DateTime created)
        {
            this.created = created;
        }

        public void SetCreated()
        {
            this.created = DateTime.Now;
        }
    }

    [OslcNamespace(Constants.Scene.SCENE_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Scene Resource Shape", describes = new string[] { Constants.Scene.TYPE_SCENE_VARIANT })]
    public class Variant : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes = new HashSet<Uri>();
        private readonly ISet<string> subjects = new HashSet<string>();
        private Uri instanceShape;


        private string identifier;
        private DateTime created;
        private string title;
        private Uri serviceProvider;
        private DateTime modified;
        private Specification specification;

        public Variant()
            : base()
        {
            rdfTypes.Add(new Uri(Constants.Scene.TYPE_SCENE_VARIANT));
        }

        public Variant(Uri about)
            : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Scene.TYPE_SCENE_VARIANT));
        }

        public void AddRdfType(Uri rdfType)
        {
            this.rdfTypes.Add(rdfType);
        }

        public void AddSubject(string subject)
        {
            this.subjects.Add(subject);
        }

        [OslcDescription("A unique identifier for a resource. Assigned by the service provider when a resource is created. Not intended for end-user display.")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "identifier")]
        [OslcReadOnly]
        [OslcTitle("Identifier")]
        public string GetIdentifier()
        {
            return identifier;
        }

        [OslcDescription("Timestamp of resource creation.")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "created")]
        [OslcReadOnly]
        [OslcTitle("Created")]
        public DateTime GetCreated()
        {
            return created;
        }

        [OslcDescription("Timestamp last latest resource modification.")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "modified")]
        [OslcReadOnly]
        [OslcTitle("Modified")]
        public DateTime GetModified()
        {
            return modified;
        }

        [OslcDescription("The resource type URIs.")]
        [OslcName("type")]
        [OslcPropertyDefinition(OslcConstants.RDF_NAMESPACE + "type")]
        [OslcTitle("Types")]
        public Uri[] GetRdfTypes()
        {
            return rdfTypes.ToArray();
        }

        [OslcDescription("The scope of a resource is a Uri for the resource's OSLC Service Provider.")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "serviceProvider")]
        [OslcRange(OslcConstants.TYPE_SERVICE_PROVIDER)]
        [OslcTitle("Service Provider")]
        public Uri GetServiceProvider()
        {
            return serviceProvider;
        }

        [OslcDescription("A Specification is a characteristic of a product, discriminates one product from other members.")]
        [OslcName("specification")]
        [OslcOccurs(Occurs.ZeroOrOne)]
        [OslcReadOnly(false)]
        [OslcPropertyDefinition(Constants.plm.PLM_NAMESPACE + "specification")]
        [OslcRange(Constants.plm.TYPE_SPECIFICATION)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("PLM related specification of a variant, which discriminates on variant from other available varaints of a variant set")]
        public Specification GetSpecification()
        {
            return specification;
        }

        [OslcDescription("Tag or keyword for a resource. Each occurrence of a dcterms:subject property denotes an additional tag for the resource.")]
        [OslcName("subject")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "subject")]
        [OslcReadOnly(false)]
        [OslcTitle("Subjects")]
        public string[] GetSubjects()
        {
            return subjects.ToArray();
        }

        [OslcDescription("Title (reference: Dublin Core) or often a single line summary of the resource represented as rich text in XHTML content.")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "title")]
        [OslcTitle("Title")]
        public string GetTitle()
        {
            return title;
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }


        public void SetIdentifier(string identifier)
        {
            this.identifier = identifier;
        }

        public void SetSpecification(Specification specification)
        {
            this.specification = specification;
        }

        public void SetModified(DateTime modified)
        {
            this.modified = modified;
        }

        public void SetRdfTypes(Uri[] rdfTypes)
        {
            this.rdfTypes.Clear();

            if (rdfTypes != null)
            {
                this.rdfTypes.AddAll(rdfTypes);
            }
        }

        public void SetServiceProvider(Uri serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void SetSubjects(string[] subjects)
        {
            this.subjects.Clear();

            if (subjects != null)
            {
                this.subjects.AddAll(subjects);
            }
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetCreated(DateTime created)
        {
            this.created = created;
        }

        public void SetCreated()
        {
            this.created = DateTime.Now;
        }
    }
    
    [OslcNamespace(Constants.Scene.SCENE_NAMESPACE)]
    [OslcResourceShape(title = "ARVIDA based Scene Resource Shape", describes = new string[]{ Constants.Scene.TYPE_SCENE_VARIANT_SET})]
    public class VariantSet : AbstractResource
    {
        private readonly ISet<Uri> rdfTypes                             = new HashSet<Uri>();
        private readonly ISet<string> subjects                          = new HashSet<string>();
        private readonly IList<Variant> variants                        = new List<Variant>();
        private Uri instanceShape;


        private string identifier;
        private DateTime created;
        private string title;
        private Uri serviceProvider;
        private DateTime modified;

        public VariantSet() : base()
        {
            rdfTypes.Add(new Uri(Constants.Scene.TYPE_SCENE_VARIANT_SET));
        }

        public VariantSet(Uri about) : base(about)
        {
            rdfTypes.Add(new Uri(Constants.Scene.TYPE_SCENE_VARIANT_SET));
        }

        public void AddRdfType(Uri rdfType)
        {
            this.rdfTypes.Add(rdfType);
        }

        public void AddSubject(string subject)
        {
            this.subjects.Add(subject);
        }

        public void AddVariant(Variant thisVariant)
        {
            this.variants.Add(thisVariant);
        }

        [OslcDescription("A unique identifier for a resource. Assigned by the service provider when a resource is created. Not intended for end-user display.")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "identifier")]
        [OslcReadOnly]
        [OslcTitle("Identifier")]
        public string GetIdentifier()
        {
            return identifier;
        }

        [OslcDescription("Timestamp of resource creation.")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "created")]
        [OslcReadOnly]
        [OslcTitle("Created")]
        public DateTime GetCreated()
        {
            return created;
        }

        [OslcDescription("Timestamp last latest resource modification.")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "modified")]
        [OslcReadOnly]
        [OslcTitle("Modified")]
        public DateTime GetModified()
        {
            return modified;
        }

        [OslcDescription("The resource type URIs.")]
        [OslcName("type")]
        [OslcPropertyDefinition(OslcConstants.RDF_NAMESPACE + "type")]
        [OslcTitle("Types")]
        public Uri[] GetRdfTypes()
        {
            return rdfTypes.ToArray();
        }

        [OslcDescription("The scope of a resource is a Uri for the resource's OSLC Service Provider.")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "serviceProvider")]
        [OslcRange(OslcConstants.TYPE_SERVICE_PROVIDER)]
        [OslcTitle("Service Provider")]
        public Uri GetServiceProvider()
        {
            return serviceProvider;
        }

        [OslcDescription("Tag or keyword for a resource. Each occurrence of a dcterms:subject property denotes an additional tag for the resource.")]
        [OslcName("subject")]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "subject")]
        [OslcReadOnly(false)]
        [OslcTitle("Subjects")]
        public string[] GetSubjects()
        {
            return subjects.ToArray();
        }

        [OslcDescription("Title (reference: Dublin Core) or often a single line summary of the resource represented as rich text in XHTML content.")]
        [OslcOccurs(Occurs.ExactlyOne)]
        [OslcPropertyDefinition(OslcConstants.DCTERMS_NAMESPACE + "title")]
        [OslcTitle("Title")]
        public string GetTitle()
        {
            return title;
        }

        [OslcDescription("ARVIDA derived object")]
        [OslcName("variant")]
        [OslcOccurs(Occurs.OneOrMany)]
        [OslcReadOnly(false)]
        [OslcPropertyDefinition(Constants.Scene.SCENE_NAMESPACE + "variant")]
        [OslcRange(Constants.Scene.TYPE_SCENE_VARIANT)]
        [OslcValueType(OSLC4Net.Core.Model.ValueType.Resource)]
        [OslcTitle("VisID - ARVIDA derived variant set")]
        public Variant[] GetVariants()
        {
            return variants.ToArray();
        }

        [OslcDescription("Resource Shape that provides hints as to resource property value-types and allowed values. ")]
        [OslcPropertyDefinition(OslcConstants.OSLC_CORE_NAMESPACE + "instanceShape")]
        [OslcRange(OslcConstants.TYPE_RESOURCE_SHAPE)]
        [OslcTitle("Instance Shape")]
        public Uri GetInstanceShape()
        {
            return instanceShape;
        }

        public void SetInstanceShape(Uri instanceShape)
        {
            this.instanceShape = instanceShape;
        }


        public void SetIdentifier(string identifier)
        {
            this.identifier = identifier;
        }

        public void SetModified(DateTime modified)
        {
            this.modified = modified;
        }

        public void SetRdfTypes(Uri[] rdfTypes)
        {
            this.rdfTypes.Clear();

            if (rdfTypes != null)
            {
                this.rdfTypes.AddAll(rdfTypes);
            }
        }

        public void SetVariants(Variant[] variants)
        {
            this.variants.Clear();

            if (variants != null)
            {
                this.variants.AddAll(variants);
            }
        }

        public void SetServiceProvider(Uri serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void SetSubjects(string[] subjects)
        {
            this.subjects.Clear();

            if (subjects != null)
            {
                this.subjects.AddAll(subjects);
            }
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetCreated(DateTime created)
        {
            this.created = created;
        }

        public void SetCreated()
        {
            this.created = DateTime.Now;
        }
    }
}