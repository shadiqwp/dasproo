import Vue from 'vue'
import VueRouter from 'vue-router'
import WebHome from '../components/WebHome.vue'
import WebLogin from '../components/WebLogin.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: WebHome
  },
  {
    path: '/login',
    name: 'login',
    component: WebLogin
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
