<template>
  <Suspense>
    <template #default>
      <div class="container d-flex flex-direction-column">
        <the-header />
        <div class="content w-100 flex1 d-flex">
          <the-sidebar />
          <the-main />
        </div>
      </div>
    </template>

    <template #fallback>
      <the-skeletion-layout />
    </template>
  </Suspense>

</template>

<script setup>
import { defineAsyncComponent } from 'vue'
import TheSkeletionLayout from './layouts/TheSkeletionLayout.vue'
const TheHeader = defineAsyncComponent(() =>
  import('@/layouts/TheHeader.vue')
)
const TheSidebar = defineAsyncComponent(() =>
  import('@/layouts/TheSidebar.vue')
)
const TheMain = defineAsyncComponent(() =>
  import('@/layouts/TheMain.vue')
)
</script>

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
