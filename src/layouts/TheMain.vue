<template>
  <div class="main-content h-100 flex1 d-flex flex-direction-column">
    <RouterView />
  </div>
</template>
<script setup>
import { RouterView } from 'vue-router'

</script>
<style scoped>
.main-content {
  /* background-color: blue; */
  padding: 16px 24px 0;
}
</style>