init();
function init(){
    const width = window.innerWidth;
    const height = window.innerHeight;
    const canvasEl = document.querySelector('#canvas');

    canvasEl.setAttribute('width', width);
    canvasEl.setAttribute('height', height);

    const renderer = new THREE.WebGLRenderer({
        canvas: canvasEl
    });
    renderer.setClearColor(0xdddddd);
    
    const scene = new THREE.Scene();
     scene.fog = new THREE.Fog(0xffffff, 400, 600);
    const camera = new THREE.PerspectiveCamera(45, width / height, 0.1, 800);
    camera.position.set(0, 0, 500);
    const light = new THREE.AmbientLight(0xffffff);
    scene.add(light);


    var meshes = [];

    const CylinderGeometry = new THREE.CylinderGeometry( 30, 30, 210, 30 );
    const CylinderMaterial = new THREE.MeshPhongMaterial({ transparent: false, map: THREE.ImageUtils.loadTexture('images/marmur.jpg') });


    const cylinder = new THREE.Mesh( CylinderGeometry, CylinderMaterial );
    meshes.push(cylinder);

    var ConeGeometry = new THREE.ConeGeometry( 32, 80, 50 );
    var ConeMaterial = new THREE.MeshBasicMaterial( {color: 0x019c01, vertexColors: THREE.FaceColors } );

    
    var cone = new THREE.Mesh( ConeGeometry, ConeMaterial );
    
    meshes.push(cone);
    cone.position.set(0, 145, 0);

    let group = new THREE.Object3D();
    group.add (cylinder);
    group.add (cone);

    scene.add(group);

    loop();


    function loop() {

        group.rotation.x += Math.PI / 100;

        renderer.render(scene, camera);
        requestAnimationFrame(() => { loop(); })
    }

};