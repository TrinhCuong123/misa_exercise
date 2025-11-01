import { createRouter, createWebHistory } from 'vue-router'
import CandidatesView from '@/views/candidate/CandidatesView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: CandidatesView,
    },
  ],
})

export default router
