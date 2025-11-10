import { createRouter, createWebHistory } from 'vue-router'
import CustomerView from '@/views/customer/customer.vue'
import SaleOrder from '@/views/sale-order/sale-order.vue'
import MainPage from '@/views/index.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  // Page router
  routes: [
    {
      path: '/',
      name: 'home',
      component: MainPage,
    },
    {
      path: '/customer',
      name: 'customer',
      component: CustomerView,
    },
    {
      path: '/sale-order',
      name: 'sale-order',
      component: SaleOrder,
    },
    // {
    //   path: '/about',
    //   name: 'about',
    //   // route level code-splitting
    //   // this generates a separate chunk (About.[hash].js) for this route
    //   // which is lazy-loaded when the route is visited.
    //   component: () => import('../views/AboutView.vue'),
    // },
  ],
})

export default router
