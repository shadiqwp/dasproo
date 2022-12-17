<template>
  <v-app>
    <div id="app">
      <img src="https://unri.ac.id/wp-content/uploads/2021/03/logo-unri2.png" height="75px" widht="300px">
      <web-toolbar></web-toolbar>
      <router-view/>
      <web-footer></web-footer>
    </div>
  </v-app>
</template>

<script>
import WebFooter from './components/WebFooter'
import WebToolbar from './components/WebToolbar'

export default {
naeme: 'App',
components:{WebFooter,WebToolbar}
}
</script>

<style>
#app {
font-family: 'Avenir', Helvetica, Arial, sans-serif;
-webkit-font-smoothing: antialiased;
-moz-osx-font-smoothing: grayscale;
text-align: left;
color: #2c3e50;
}
</style>