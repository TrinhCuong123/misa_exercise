<template>
  <div class="container d-flex flex-column">
    <the-header/>
    <div class="main flex1 d-flex w-100-percent">
      <the-side-bar/>
      <the-main/>
    </div>
  </div>
</template>

<script setup>
import TheHeader from './layout/TheHeader.vue';
import TheMain from './layout/TheMain.vue';
import TheSideBar from './layout/TheSideBar.vue';
</script>

<style scoped>
.container {
  height: 100%;
  height: 100vh;
}


</style>
