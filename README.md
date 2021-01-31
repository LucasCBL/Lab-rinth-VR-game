# Informe Lab-rinth
## Lucas Christian Bodson Lobato

## Guillermo Hernández González


> ### Cuestiones importantes para el uso

Las cosas importantes para tener en cuenta son las siguientes:

* El juego está pensado para jugarse con un mando de Playstation
* Para apuntar en el juego se usa el raycast de Google, eso significa que es necesario mover la cabeza para el apuntado.
* En el caso de no saber como avanzar, hay un playthrough en el siguiente [enlace](https://drive.google.com/file/d/1YC_BZ41G88PuPUSGAnSdrg4XwEAKXvib/view?usp=drivesdk)

> ### Mecánicas del juego

* El jugador podrá moverse en el mundo con libertad, tanto en horizontal como en vertical ya que hay una mecánica de salto.
  ![salto](RECURSOS%20README/salto-movimiento.gif)
* El jugador podrá vez de que color tiene su "luz"
  ![luz](RECURSOS%20README/activar-luz-mano.gif)
* El jugador interactuar y algunos objetos que se encuentre, entre ellos cubos y colores
  ![coger_objeto](RECURSOS%20README/coger-obj-placa-presion.gif)
  ![cambiar_luz](RECURSOS%20README/cambiar-color-mano.gif)
* El jugador tiene a su disposiciones dos armas, una espara para atacar cuerpo a cuerpo y magia para atacar a distancia.
  ![ataque_espada](RECURSOS%20README/ataque-espada.gif)
  ![ataque_distancia](RECURSOS%20README/ataque-distancia-diana.gif)
* Habrá muros en el juego que el jugador podrá romper con un ataque cuerpo a cuerpo
  ![romper_muro](RECURSOS%20README/romper-muro.gif)
* También habrá dianas que el jugador pueda atacar a distancia con magia y activar varios mecanismos
  ![ataque_diana](RECURSOS%20README/ataque-distancia-diana.gif)
* Hay placas de presiones donde el jugador puede colocar un cubo encima para activar mecanismos 
  ![placa](RECURSOS%20README/coger-obj-placa-presion.gif)
* Depende del color que tengas, encenderás las antorchas con ese color en específico
  ![luz_color](RECURSOS%20README/puzle-color.gif)


> ### Aspectos que destacarías en la aplicación. Especificar si se han incluido sensores de los que se han trabajado en interfaces multimodales.
Podemos descatar que juntando todas las mecánicas que hemos hecho podríamos expandir el juego bastante y hacer puzles mucho más complejos.
Otra cosa que hay que destacar es que hicimos pequeñas animaciones para los ataques, tanto del jugador como del enemigo.
![ataque_enemigo](RECURSOS%20README/esqueleto-puerta-enemigos.gif)
En el gif de arriba también podemos ver otro de las cosas que hicimos y es que hayan diferente tipos de "puertas" que bloquean el camino hasta que hagas algo en específico.
* Para abrir las puertas rojas tienes que matar a los enemigos de la sala para que desaparezca
* Las puertas verdes es necesario darle a una diana con magia para abrirlas
* Las puertas azules es necesario resolver un puzle para que se abran

Para evitar el mareo intentamos en lo mayor de lo posible los movimientos bruscos con la cabeza ya que el uso de este movimiento realmente solo sirve para mirar alrededor tuyo o apuntar.

Otra forma que usamos para evitar el mareo son las transiciones entre escena y escena. Estas se harán a través de un fundido a negro y luego de negro a la nueva escena.

Hicimos que la cámara esté fijada al usuario y sea este el que la controle todo el tiempo para evitar posibles mareos debido a un movimiento de la cámara.

Hablando de sensores, implementamos una brújula que le servirá al jugador para orientarse en las diferentes salas.

[![Watch the video](RECURSOS%20README/brujula.jpg)](https://youtu.be/vt5fpE0bzSY)

(Pulsar en la imagen para acceder al vídeo)
> ### Gif animados de ejecución

Aquí tenemos un vídeo entero del juego ejecutado en un móvil

[![Watch the video](RECURSOS%20README/game.jpg)](https://drive.google.com/file/d/1YC_BZ41G88PuPUSGAnSdrg4XwEAKXvib/view?usp=drivesdk)

(Pulsar en la imagen para acceder al vídeo)
> ### Acta de los acuerdos del grupo respecto al trabajo en equipo: reparto de tareas, tareas desarrolladas individualmente, tareas desarrolladas en grupo, etc.

- Guillermo Hernández González
  - Decoración
  - Diseño de niveles
  - Diseño de puzles
  - Diseño del mapa
  - Beta testing
- Lucas Christian Bodson Lobato
  - Diseño de partículas
  - Diseño de sonido
  - Diseño de mecánicas
  - Diseño de tutoriales
  - Animador
- Común
  - Programación
