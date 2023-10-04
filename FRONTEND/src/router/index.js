import { createRouter, createWebHistory } from 'vue-router'
import Home from '../Vistas/Home.vue'
import RegistroEmpresa from '../Vistas/RegistroEmpresa.vue'
import RegistroUsuario from '../Vistas/RegistroUsuario.vue'
<<<<<<< HEAD
import Login from '../Vistas/Login.vue'
=======
import Inicio from '../Vistas/Inicio.vue'
>>>>>>> cf3f8813b32667522f718b6c8cdec5b7ef93a852

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/RegistroEmpresa',
      name: 'RegistroEmpresa',
      component: RegistroEmpresa
    },
    {
      path: '/RegistroUsuario',
      name: 'RegistroUsuario',
      component: RegistroUsuario
    },
    {
<<<<<<< HEAD
      path: '/Login',
      name: 'login',
      component: Login 
=======
      path: '/Inicio',
      name: 'Inicio',
      component: Inicio
>>>>>>> cf3f8813b32667522f718b6c8cdec5b7ef93a852
    },
  ]
})

export default router
