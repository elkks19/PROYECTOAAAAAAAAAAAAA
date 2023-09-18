import { createRouter, createWebHistory } from 'vue-router'

import Prueba from '../components/Prueba.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: Prueba
    },
  ]
})

export default router
