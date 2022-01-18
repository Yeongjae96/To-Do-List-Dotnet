import { createWebHistory, createRouter } from 'vue-router';

import Home from '@/pages/Home'
import Error404 from '@/pages/error/404'
const routes = [
  {
    path: '/',
    redirect: '/Home'
  },
  { name: 'Home', path: '/home', component: Home },
  { path: '/:pathMatch(.*)*', component: Error404 },
];

const router = createRouter({
  history: createWebHistory(),
  linkActiveClass: "active",
  routes, 
});

export default router;