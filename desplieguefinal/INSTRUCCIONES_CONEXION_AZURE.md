# 🔧 Instrucciones para Configurar la Conexión de Servicio de Azure

## Problema
El pipeline muestra el error: "service connection does not exist, has been disabled or has not been authorized for use"

## Solución: Crear la Conexión de Servicio de Azure

### Paso 1: Acceder a Service Connections
1. En Azure DevOps, ve a tu proyecto
2. Haz clic en el icono de **⚙️ Project Settings** (esquina inferior izquierda)
3. En el menú lateral, busca y haz clic en **Service connections** (bajo "Pipelines")

### Paso 2: Crear Nueva Conexión
1. Haz clic en el botón **"New service connection"** o **"+ Create service connection"**
2. Selecciona **"Azure Resource Manager"**
3. Haz clic en **"Next"**

### Paso 3: Configurar la Autenticación
1. Selecciona **"Workload Identity federation (automatic)"** (recomendado) o **"Service principal (automatic)"**
2. Haz clic en **"Next"**

### Paso 4: Configurar el Scope
1. **Subscription**: Selecciona tu suscripción de Azure (donde está el App Service "desplieguefinal")
2. **Resource group**: Selecciona **"Entregafinal"** (o el grupo de recursos donde está tu App Service)
3. **Service connection name**: Ingresa exactamente: **`Azure-Connection-desplieguefinal`**
   - ⚠️ **IMPORTANTE**: El nombre debe ser exactamente este, sin espacios adicionales
4. Marca la casilla **"Grant access permission to all pipelines"** (opcional pero recomendado)
5. Haz clic en **"Save"**

### Paso 5: Verificar la Conexión
1. Deberías ver la conexión en la lista con el nombre "Azure-Connection-desplieguefinal"
2. El estado debe ser "Ready" (verde)

### Paso 6: Ejecutar el Pipeline
1. Ve a **Pipelines** > **Pipelines**
2. Selecciona tu pipeline
3. Haz clic en **"Run pipeline"**
4. El despliegue debería funcionar ahora

---

## 🔍 Verificación del Error de GitHub (Release Pipeline)

Si estás intentando usar un **Release Pipeline** (el antiguo sistema) y ves el error de GitHub:

### Solución Alternativa: Usar YAML Pipeline (Recomendado)
El archivo `azure-pipelines.yml` ya está configurado para CI/CD completo. **No necesitas un Release Pipeline separado**.

### Si necesitas usar Release Pipeline:
1. Ve a **Pipelines** > **Releases**
2. En lugar de crear un nuevo release pipeline, usa el pipeline YAML que ya tienes
3. El pipeline YAML incluye tanto CI como CD en un solo archivo

---

## ✅ Checklist de Configuración

- [ ] Conexión de servicio de Azure creada con nombre: `Azure-Connection-desplieguefinal`
- [ ] La conexión tiene acceso a la suscripción correcta
- [ ] La conexión tiene acceso al Resource Group "Entregafinal"
- [ ] El pipeline YAML está en la rama `main`
- [ ] El App Service "desplieguefinal" existe en Azure
- [ ] El pipeline se ejecuta correctamente (CI funciona)
- [ ] El despliegue se ejecuta automáticamente después del build (CD funciona)

---

## 🎥 Para el Video de CD

Cuando grabes el video demostrando CD, muestra:
1. Hacer un cambio en el código (ej: modificar Program.cs)
2. Hacer commit y push a la rama `main`
3. El pipeline se ejecuta automáticamente (CI)
4. El despliegue se ejecuta automáticamente (CD)
5. Verificar que la aplicación está actualizada en `https://desplieguefinal.azurewebsites.net`

---

## 📝 Notas Importantes

- El pipeline YAML (`azure-pipelines.yml`) ya incluye CI y CD en un solo archivo
- No necesitas crear un Release Pipeline separado
- El despliegue se ejecuta automáticamente después de cada build exitoso
- El trigger está configurado para la rama `main`

