import { createRouter, createWebHistory } from 'vue-router'
import Home from '../Vistas/Home.vue'
import RegistroEmpresa from '../Vistas/RegistroEmpresa.vue'
import RegistroUsuario from '../Vistas/RegistroUsuario.vue'
import Inicio from '../Vistas/Inicio.vue'
import Paginaproducto from '../Vistas/Paginaproducto.vue'


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
      path: '/Inicio',
      name: 'Inicio',
      component: Inicio
    },
    {
      path: '/paginaproducto',
      name: 'Productos',
      component: Paginaproducto
    },
  ]
})

export default router
