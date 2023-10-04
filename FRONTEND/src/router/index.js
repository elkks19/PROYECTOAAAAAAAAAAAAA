import { createRouter, createWebHistory } from 'vue-router'
import Home from '../Vistas/Home.vue'
import RegistroEmpresa from '../Vistas/RegistroEmpresa.vue'
import RegistroUsuario from '../Vistas/RegistroUsuario.vue'

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
  ]
})

export default router
