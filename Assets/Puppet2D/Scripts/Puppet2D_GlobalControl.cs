using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[ExecuteInEditMode]
public class Puppet2D_GlobalControl : MonoBehaviour {

	public float startRotationY;

	public List<Puppet2D_IKHandle> _Ikhandles = new List<Puppet2D_IKHandle>();
	public List<Puppet2D_ParentControl> _ParentControls = new List<Puppet2D_ParentControl>();

	private List<SpriteRenderer> _Controls = new List<SpriteRenderer>();
	private List<SpriteRenderer> _Bones = new List<SpriteRenderer>();

	public bool ControlsVisiblity = true;
	public bool BonesVisiblity = true;
	public bool CombineMeshes = false;

	public bool flip = false;
	private bool internalFlip = false;

	public bool AutoRefresh = true;




	//public float boneSize;
	// Use this for initialization
	void OnEnable () 
	{
		if (AutoRefresh)
		{
			_Ikhandles.Clear();
			_ParentControls.Clear();
			_Controls.Clear();
			TraverseHierarchy(transform);
		}

	}
	public void Refresh() 
	{
		_Ikhandles.Clear();
		_ParentControls.Clear();
		_Controls.Clear();
		TraverseHierarchy(transform);

	}
	void Awake () 
	{
		internalFlip = flip;
		if(Application.isPlaying)
		{
			if(CombineMeshes)			
				CombineAllMeshes();

		}


	}
	// Update is called once per frame
	public void Init()
	{       
		_Ikhandles.Clear();
		_ParentControls.Clear();
		_Controls.Clear();
		TraverseHierarchy(transform);

	}
	void OnValidate ()
	{

		foreach(SpriteRenderer ctrl in _Controls)
		{
			if(ctrl)
				ctrl.enabled = ControlsVisiblity;
		}
		foreach(SpriteRenderer bone in _Bones)
		{
			if(bone)
				bone.enabled = BonesVisiblity;
		}

	}
	void Update () 
	{

		foreach(Puppet2D_ParentControl parentControl in _ParentControls)
		{
			if(parentControl)
				parentControl.ParentControlRun();
		}
		FaceCamera();
		foreach(Puppet2D_IKHandle ik in _Ikhandles)
		{
			if(ik)
				ik.CalculateIK();
		}

		if (internalFlip != flip)
		{
			if (flip)
			{

				transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -transform.localScale.z);
				transform.localEulerAngles = new Vector3(transform.rotation.eulerAngles.x, startRotationY + 180, transform.rotation.eulerAngles.z);

			}
			else
			{

				transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), Mathf.Abs(transform.localScale.y), Mathf.Abs(transform.localScale.z));
				transform.localEulerAngles = new Vector3(transform.rotation.eulerAngles.x, startRotationY, transform.rotation.eulerAngles.z);

			}
			internalFlip = flip;
		}





	}
	public void Run () 
	{

		foreach(Puppet2D_ParentControl parentControl in _ParentControls)
		{
			if(parentControl)
				parentControl.ParentControlRun();
		}
		FaceCamera();
		foreach(Puppet2D_IKHandle ik in _Ikhandles)
		{
			if(ik)
				ik.CalculateIK();
		}




	}
	void TraverseHierarchy(Transform root) 
	{

		foreach (Transform child in root) 
		{
			GameObject Go = child.gameObject;
			SpriteRenderer spriteRenderer = Go.transform.GetComponent<SpriteRenderer>();
			if (spriteRenderer)
			{
				if(spriteRenderer.sprite.name.Contains("Control"))
					_Controls.Add(spriteRenderer);
				else if(spriteRenderer.sprite.name.Contains("Bone"))
					_Bones.Add(spriteRenderer);
			}
			Puppet2D_ParentControl newParentCtrl = Go.transform.GetComponent<Puppet2D_ParentControl>();

			if (newParentCtrl)
			{
				_ParentControls.Add(newParentCtrl);

			}
			Puppet2D_IKHandle newIKCtrl = Go.transform.GetComponent<Puppet2D_IKHandle>();
			if (newIKCtrl)
				_Ikhandles.Add(newIKCtrl);


			TraverseHierarchy(child);

		}

	}
	void CombineAllMeshes() 
	{      
		Vector3 originalScale = transform.localScale;
		Quaternion originalRot = transform.rotation;
		Vector3 originalPos = transform.position;
		transform.localScale = Vector3.one;
		transform.rotation = Quaternion.identity;
		transform.position = Vector3.zero;

		SkinnedMeshRenderer[] smRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
		List<Transform> bones = new List<Transform>();        
		List<BoneWeight> boneWeights = new List<BoneWeight>();        
		List<CombineInstance> combineInstances = new List<CombineInstance>();
		List<Texture2D> textures = new List<Texture2D>();
		int numSubs = 0;
		var smRenderersDict = new Dictionary<SkinnedMeshRenderer, float>(smRenderers.Length);

		bool updateWhenOffscreen = false;

		foreach(SkinnedMeshRenderer smr in smRenderers)
		{
			smRenderersDict.Add(smr, smr.transform.position.z);
			updateWhenOffscreen = smr.updateWhenOffscreen;
		}
		var items = from pair in smRenderersDict
			orderby pair.Value descending
				select pair;
		foreach (KeyValuePair<SkinnedMeshRenderer, float> pair in items)
		{
			//Debug.Log(pair.Key.name + " " + pair.Value);
			numSubs += pair.Key.sharedMesh.subMeshCount;
		}

		int[] meshIndex = new int[numSubs];
		int boneOffset = 0;

		int s = 0;
		foreach (KeyValuePair<SkinnedMeshRenderer, float> pair in items)
		{
			SkinnedMeshRenderer smr = pair.Key;    

			BoneWeight[] meshBoneweight = smr.sharedMesh.boneWeights;

			foreach( BoneWeight bw in meshBoneweight ) {
				BoneWeight bWeight = bw;

				bWeight.boneIndex0 += boneOffset;
				bWeight.boneIndex1 += boneOffset;
				bWeight.boneIndex2 += boneOffset;
				bWeight.boneIndex3 += boneOffset;                

				boneWeights.Add( bWeight );
			}
			boneOffset += smr.bones.Length;

			Transform[] meshBones = smr.bones;
			foreach( Transform bone in meshBones )
				bones.Add( bone );

			if( smr.material.mainTexture != null )
				textures.Add( smr.renderer.material.mainTexture as Texture2D );

			CombineInstance ci = new CombineInstance();
			ci.mesh = smr.sharedMesh;
			meshIndex[s] = ci.mesh.vertexCount;
			ci.transform = smr.transform.localToWorldMatrix;
			combineInstances.Add( ci );

			Object.Destroy( smr.gameObject );
			s++;
		}

		List<Matrix4x4> bindposes = new List<Matrix4x4>();

		for( int b = 0; b < bones.Count; b++ ) {
			bindposes.Add( bones[b].worldToLocalMatrix * transform.worldToLocalMatrix );
		}

		SkinnedMeshRenderer r = gameObject.AddComponent<SkinnedMeshRenderer>();

		r.updateWhenOffscreen = updateWhenOffscreen;
		r.sharedMesh = new Mesh();
		r.sharedMesh.CombineMeshes( combineInstances.ToArray(), true, true );

		Material combinedMat = new Material( Shader.Find( "Unlit/Transparent" ) );
		combinedMat.mainTexture = textures[0];
		r.sharedMesh.uv = r.sharedMesh.uv;
		r.sharedMaterial = combinedMat;

		r.bones = bones.ToArray();
		r.sharedMesh.boneWeights = boneWeights.ToArray();
		r.sharedMesh.bindposes = bindposes.ToArray();
		r.sharedMesh.RecalculateBounds();


		transform.localScale =originalScale;
		transform.rotation = originalRot;
		transform.position =originalPos;
	}
	void FaceCamera(){

		foreach (Puppet2D_IKHandle p in _Ikhandles) 
		{

			p.AimDirection = transform.forward.normalized; 

			//change the aiming of IK to the forward vector of the camera 

		}

	}
}
