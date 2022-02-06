# RUBIKCUBEII
Cubo de Rubik interactivo

## Cuestiones importantes para el uso:
Lo p
## Hitos de programación logrados relacionándolos con los contenidos que se han impartido:
**Intefaces multimodales:** capturar la posición del GPS.  
**Gestión de Eventos:** Uso de lo visto en delegados y eventos para llevar los eventos.  
**Aplicación de lógica de transforms:** Uso de lo visto en el tema de modificar transform para llevar a cabo movimientos.  
**Elementos de la interfaz:** Integración de elementos que hacen más clara la interfaz, como por ejemplo usar raycasting para generar el mapa del cubo e integrarlo dentro de la casa    
**Uso de los elementos de VR:** Integrar controles para un uso correcto en un espacio de realidad Virtual con las carboard.   
**Movimiento del jugador:** Creamos un movimiento para el jugador con lo visto en clase.
## Aspectos que destacarías en la aplicación.
El aspecto principal que destacariamos sería la integración de diferentes elementos para la inmersión del jugador dentro del entorno, por ejemplo tener el mapa del cubo que nos indica su estado como si fuera un cuadro, tener el panel de control encima de la mesa como si realmente estuviera ahí.  
Luego hablando más del cubo, sigue una lógica muy compleja detrás de muchas clases y uso de quaterniones para girar las caras de manera realtiva al centro, además cambiamos la herencia de las piezas dinámicamente para que se puedan girar las caras a partir de un eje de rotación. Usamos rayos de luz para mapear el estado del cubo y usamos un sistema complejo para generar rotaciones de manera dinamica, además hacemos correcciones a la hora de girar una cara para que el usuario no tenga que hacer todo el movimiento.
## Organización de tareas:
### -Grupales:
- Creación de la presentación
- Redacción del README.md
- Eleccion de idea a implementar
- Elección de los diferentes elementos que vamos a usar
### -Individuales:
Marcos:
- Creación del modelo del cubo    
- Creación del entorno y los scripts de interacción    
- Creación de la lógica detrás de los rayos de luz  
- Creación del movimiento automático  
  
Manuel:  
- Creación del script del estado del cubo  
- Creación y redacción del README.md  
- Creación de la rotacion del propio cubo  
- Creación de la corrección de la posición de la cara 


Pablo:  
- Creación del mapeo del cubo  
- Creación del temporizador  
- Creación de la lógica de los controles del jugador  
- Creación de la herencia dinámica  


Francesco:  
- Creación de la integración del GPS  
- Organizador de las quedadas del grupo  
- Proporcionar recursos bibliográficos interesantes  
- Proporciono mejora en la implementación de la librería de la realidad virtual  


## Ejecución:
https://user-images.githubusercontent.com/72877378/152649595-94caef77-82a5-4dd3-bbda-ea6c1bfcef40.mp4

![gps](https://user-images.githubusercontent.com/72877378/152649984-a6a39249-d66d-4f6e-a6e1-844af00ccde0.gif)
