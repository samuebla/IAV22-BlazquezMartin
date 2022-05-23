# IAV22-BlázquezMartín

# Tracost the Bull

Enlace al video con las pruebas: https://www.youtube.com/watch?v=GkhsaKt52Zo

La idea descrita va a ser desarrollada por un grupo de dos integrantes: Samuel Blázquez Martín y Miguel Hernández García.

Partiremos de un proyecto de Unity en blanco y desarrollaremos a partir de ahí una batalla de jefe final.
En la escena habrá un jugador que podrá moverse en un escenario 3D y atacar a un enemigo mientras esté a un rango considerable, pudiendo atacar a distancia.
También habrá un boss que tendrá una barra de vida y una máquina de estados. Emplearemos Bolt para implementar esta máquina de estados en Unity. El boss realizará una serie de ataques dependiendo del tiempo transcurrido en el encuentro.

El jugador deberá de moverse por el escenario evitando los ataques del boss y disminuyendo su vida. (Para más claridad la barra de vida del boss será mostrada continuamente en pantalla). Si el jugador no realiza suficiente daño durante el transcurso de la pelea este morirá por la última habilidad del boss (Titanic Roar) que realizará 5 puntos de daño a toda la arena.

En el caso de que el jugador reciba demasiado daño, este perderá la partida.

Ambos integrantes se encargarán del desarrollo de la máquina de estados y acciones del boss, nos encargaremos de describir en la documentación las partes que han sido desarrolladas por cada uno de los integrantes.

# Descripción en detalle de la solución a implementar

A) Escena en vista perspectiva 3D en 3ª persona con un escenario en forma de cuadrado. Camara con movimiento horizontal y zoom.

B) Delimitar la zona con un muro de fuego que haga insta-kill.

C) Jugador con movimiento mediante WASD sin posibilidad de salto. El jugador podrá moverse con libertad por el escenario a una velocidad fija. También podrá atacar al Boss presente en la sala pulsando la Barra Espaciadora. En el momento en el que el jugador pulse la barra espaciadora deberá de quedarse quieto durante 3 segundos o el ataque se cancelará. Si el jugador ha esperado 3 segundos después de pulsar la Barra espaciadora, este hará daño al boss, reflejándose en la interfaz.

D) Interfaz que muestre todo lo mencionado, desde las vidas del jugador y del boss, hasta las barras de casteo de ambos (Barras de progreso que comenzarán el ataque especificado al terminar la barra).

E) Creación de Boss e implementación de una maquina de estados en Bolt que realizará un patrón de ataques en orden con ciertas variaciones. Las habilidades del Boss se especificarán más adelante.

F) El Boss realizará siempre los mismos ataques en el mismo orden, sin embargo algunos ataques tendrán variaciones diferentes que cambiarán significativamente su funcionamiento. El jugador deberá de identificar a tiempo el tipo de ataque para evitar recibir daño. Antes de realizar un ataque el nombre del ataque será mostrado en pantalla junto a una barra de progreso. Cuando la barra de progreso finalice el ataque será realizado. Todos los ataques durante este tiempo mostrarán también un indicador visual en el mapa para ayudar al jugador a identificar las zonas donde ese ataque impactará.

El jugador tiene un total de 5 corazones durante la partida, perdiendo un corazón por cada golpe que reciba (Excepto por Titanic Roar o el fuego que rodea la arena, en cuyo caso perderá 5 corazones).

# Diseño del Boss

El Boss tiene como tema principal la Roca y empleará distintos ataques utilizando su entorno y su fuerza bruta para acabar con el jugador.

Estos ataques incluyen:

- Ataques localizados en zonas específicas del escenario que hacen daño al jugador.

- Ataques que empujarán al jugador desde su punto de origen.

- Ataques que el jugador debe de evitar cubriéndose en rocas que irán apareciendo por el mapa.

![Timeline](timeline.png)

# Pseodocódigo

Realizaremos una estructura de acciones que tendrá un funcionamiento parecido al siguiente:

```
timeTimerStarted: int = currentTime
actualTime: int = currentTime

castDuration: int = 5000

while timeTimerStarted + castDuration > actualTime:
  # Actualizamos la barra de progreso del cast
  progressBar.setProgress(actualProgress)

# Hacemos la acción cuando finalice
accion.do()

```

Realizaremos un metodo por cada acción a realizar, estas acciones instanciarán representaciones visuales del ataque y un trigger que aplicará daño al jugador.

# Notas generales sobre las contribuciones

Intentamos separar las tareas de forma más o menos equitativa al ser un proyecto de dos integrantes, y planeando utilizar pair-programming de forma esporádica, sin embargo tuvimos una complicación inesperada.

1 semana antes de la entrega, el ordenador de Miguel Hernández García se apagó y no se ha vuelto a encender a dia de hoy, parece ser un problema con la placa base que aún está en reparación. Hasta encontrar una alternativa aprovechamos para avanzar aspectos no relacionados con el comportamiento del boss haciendo pair-programming. Afortunadamente esto no retrasó demasiado el desarrollo del proyecto y a día de hoy contamos con un boss del que ambos estamos orgullosos. 

# Contribuciones individuales Samuel Blázquez Martín

- Arte del juego, excepto indicadores de ataques y textura del suelo.

- Interfaz (ProgressBar.cs, UIManager.cs)

- Sonido

- Control jugador (Health.cs, Player Controller.cs)

- Ciclo de juego (GameManager.cs, DeadZone.cs, WinOrLose.cs)

- Algunos ataques y comportamientos del boss (Landslide.cs, LookAtPlayer.cs, TitanicSlam.cs, triggerEarthPulse.cs, triggerEarthquake.cs, triggerLandslide.cs)

# Contribuciones individuales Miguel Hernández García

- Implementación de Bolt en el proyecto y realización de máquina de estados (StateMachineBoss)

- Realización de estructura BossAction de la cual heredan todas las habilidades del boss y facilitan enormemente la implementación en Bolt (BossAction.cs)

- La mayoría de las habilidades del boss (EarthExpulsion.cs, RockHealth.cs, EarthPulse.cs, EarthPulseTile.cs, Earthquake.cs, Roar.cs, Rockbuster.cs, SeedInitializationTool.cs, TitanicRoar.cs)

# Controles

El jugador puede moverse mediante las teclas WASD. También puede girar la cámara manteniendo pulsado el botón derecho del ratón y moviendo el ratón de izquierda a derecha. Con la rueda del ratón se puede acercar o alejar la cámara del jugador. Nos inspiramos en Final Fantasy XIV para este movimiento.

Para hacer daño al boss el jugador debe de pulsar la barra espaciadora y quedarse quieto durante 3 segundos. Si el jugador se mueve en cualquier momento antes de que estos 3 segundos transcurran el ataque se cancelará.

# Assets externos

La gran mayoría de assets presentes en el juego son tomados de la Assets Store de Unity, sin embargo los indicadores de habilidades fueron desarrollados manualmente por Miguel Hernández García.

Para el apartado musical utilizamos canciones de Dark Fantasy Studio. Contamos con la licencia necesaria para utilizar estas canciones y distribuir nuestro producto con ellas incluidas en su totalidad.

# Notas finales

Esperamos que disfruten del producto final de este boss altamente inspirado en Eden's Gate: Sepulture (Titan Eden) de Final Fantasy XIV Online Shadowbringers. Para nosotros ha sido un gran proyecto de descubrimiento y experimentación. Hemos mantenido la dificultad del encuentro a muy asequible para que sea disfrutable para una gran variedad de personas. Suerte siendo empujados y quemados en la arena.

# Referencias

AI for games Third Edition by Ian Millington

https://unity.com/es/products/unity-visual-scripting

https://docs.unity3d.com/

Final Fantasy XIV

Furi
