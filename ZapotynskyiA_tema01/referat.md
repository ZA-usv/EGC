# **OpenGL vs Vulkan vs DirectX**

## Cuprins
* [OpenGL vs Vulkan vs DirectX](#OpenGL%20vs%20Vulkan%20vs%20DirectX)
  * [Vulkan](#Vulkan)
  * [DirectX](#DirectX)
  * [OpenGL](#OpenGL)
* [Răspuns la Întrebare](#Răspuns%20la%20Întrebare)

## OpenGL vs Vulkan vs DirectX
### Vulkan
A fost proiectat pentru a oferi o alternativă mai eficientă și de nivel mai scăzut față de OpenGL, cu scopul de a minimiza numărul de apeluri API necesare pentru a reda un cadru.    
Un alt avantaj al Vulkan este suportul pentru fire multiple, ceea ce permite aplicațiilor să utilizeze mai multe nuclee de CPU pentru a paraleliza sarcinile. Acest lucru poate duce la o creștere semnificativă a performanței în comparație cu API-urile care rulează pe un singur fir, cum ar fi OpenGL.

### DirectX
DirectX este un API grafic proprietar dezvoltat de Microsoft pentru a fi utilizat pe sistemul de operare Windows.

### OpenGL
Unul dintre principalele avantaje ale OpenGL este portabilitatea sa, fiind suportat pe o gamă largă de platforme, inclusiv Windows, Mac și Linux. Cu toate acestea, OpenGL este un API de nivel mai înalt comparativ cu Vulkan, ceea ce înseamnă că necesită mai multe apeluri API pentru a reda un cadru. Acest lucru poate duce la performanțe mai puțin eficiente, în special pe hardware modern cu procesoare grafice puternice.

## Răspuns la Întrebare 
**Întrebare:** Cum explicați modelul de automat cu stări finite al OpenGL și cum
afectează acest lucru procesul de randare al scenei 3D de către
biblioteca grafică/API?

**Răspuns:** În orice moment dat, OpenGL are o "stare" specifică, care include lucruri precum culorile curente, texturile sau transformările. Dezvoltatorul interacționează cu OpenGL prin emiterea de instrucțiuni (cum ar fi desenarea formelor sau aplicarea transformărilor), ceea ce determină schimbarea stării. Aceste schimbări de stare au loc în pași discreți, conducând la scena 3D finală redată.

În acest fel, fiecare acțiune din OpenGL—cum ar fi desenarea sau aplicarea unei transformări—modifică starea sistemului. Scena 3D finală este rezultatul efectului cumulativ al tuturor acestor acțiuni, pornind de la starea inițială implicită atunci când sistemul este inițializat.
