<template>
  <div class="card1 loading">
    <div class="skeletor-container">
      <div class="skeletor-header">
      </div>

      <div class="skeletor-body">
        <div class="sidebar">
        </div>

        <div class="content">
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
/* === Layout === */
.skeletor-container {
  display: flex;
  flex-direction: column;
  width: 100%;
  height: 100vh;
}

.skeletor-header {
  height: 48px;
  width: 100%;
  background-color: white;
  margin-bottom: 10px;
}

.skeletor-body {
  flex: 1;
  display: flex;
}

.skeletor-body .sidebar {
  width: 220px;
  background-color: white;
  margin: 10px;
  border-radius: 8px;
}

.skeletor-body .content {
  flex: 1;
  background-color: white;
  margin: 10px;
  border-radius: 8px;
}

/* === Skeleton styles === */
.loading .skeletor-header,
.loading .skeletor-body .sidebar,
.loading .skeletor-body .content {
  position: relative;
  overflow: hidden;
}

.loading .skeletor-header::before,
.loading .skeletor-body .sidebar::before,
.loading .skeletor-body .content::before {
  content: '';
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: #e0e0e0;
}

.loading .skeletor-header::after,
.loading .skeletor-body .sidebar::after,
.loading .skeletor-body .content::after {
  content: '';
  position: absolute;
  top: 0;
  left: -50%;
  width: 50%;
  height: 100%;
  background: linear-gradient(to right,
      transparent,
      rgba(255, 255, 255, 0.6),
      transparent);
  animation: skeletonLoading 1.5s infinite;
}

@keyframes skeletonLoading {
  100% {
    left: 100%;
  }
}
</style>