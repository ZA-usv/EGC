##### 1. Ce este un viewport?
Ochii jucatorului

##### 2. Ce reprezintă conceptul de frames per seconds din punctul de vedere al bibliotecii OpenGL?
nr. de poligoane disponibile per second / nr. de poligoane necesare pentru a randa scena = FPS

##### 3. Când este rulată metoda OnUpdateFrame()?
Innainte de a randa scena, aici se actualizeaza logica jocului.

##### 4. Ce este modul imediat de randare?
In modul imediat trimitem date pentru randare (puncte/linii/triunghiuri) direct fara sa le stocam in memoria GPU.

##### 5. Care este ultima versiune de OpenGL care acceptă modul imediat?
Modul imediat a fost deprecierat în OpenGL 3.0 și complet eliminat în OpenGL 3.1.

##### 6. Când este rulată metoda OnRenderFrame()?
dupa `onUpdateFrame()`

##### 7. De ce este nevoie ca metoda OnResize() să fie executată cel puțin o dată?
Ca initial window e 0 width, 0 height, apoi se face resize pina la width/height setate in program

##### 8. Ce reprezintă parametrii metodei CreatePerspectiveFieldOfView() și care este domeniul de valori pentru aceștia?
1 - Field of View descrie unghiul camerei pe verticala (cit de mult este vizibil)
2 - Aspect ratio
3 - Distanta fata de camera (ce este mai aproape este taiat) 
4 - Distanta maxima la care obiecte sunt desenate