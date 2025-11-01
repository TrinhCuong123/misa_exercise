<script setup>
import TheHeader from '@/layouts/TheHeader.vue'
import TheSidebar from '@/layouts/TheSidebar.vue'
import TheMain from '@/layouts/TheMain.vue'
</script>

<template>
  <!-- Container -->
  <div class="container d-flex flex-direction-column">
    <!-- Header -->
    <the-header />
    <!-- Main content -->
    <div class="content w-100 flex1 d-flex">
      <!-- Sidebar -->
      <the-sidebar />
      <!-- Main content -->
      <the-main />
    </div>
  </div>
</template>

<style scoped>
.content {
  background-color: #ebecef;
}

.container {
  width: 100%;
  height: 100vh;
  background-color: aqua;

  /* Cách 2 */
  /* 
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
  */
}
</style>
