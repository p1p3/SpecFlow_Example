Característica: RegistroTePresta
Yo como cliente de una de las marcas de Grupo Gente Te Presta (Beto Te Presta, Pepe Te Presta, Chamba Te Presta, Chepe Te Presta)
Quiero registrarme en la sucursal virtual 
Para solicitar créditos

@HU017,HU018
Escenario: Registro usuario con teléfono diferente 
	Dado he ingresado a te presta 
	 Y he presionado Registrarse
	 Y he ingresado mi documento único de identidad
	 Y he confirmado mi número de documento
	 Y he ingresado un número celular diferente al registrado
	 Y he presionado enviar código de verificación
	 Y he ingresado el código recibido en mi celular
	 Y he presionado verificar
	 Y he ingresado mi correo electrónico 
	 Y he presionado continuar 
	 Y he dado respuesta a las preguntas de seguridad
	 Y he ingresado mi contraseña de registro
	 Y he confirmado mi contraseña de registro
	 Y he seleccionado las preguntas personalizadas para recuperar mi contraseña
	Cuando presione registrar
	Entonces debo ingresar exitosamente a mi estado de cuenta
